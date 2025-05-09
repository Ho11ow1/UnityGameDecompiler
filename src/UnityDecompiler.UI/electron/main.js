import { app, BrowserWindow } from 'electron';
import { fileURLToPath } from 'url';
import path from 'path';
import http from 'http';

const __filename = fileURLToPath(import.meta.url);
const __dirname = path.dirname(__filename);

let mainWindow;

function isUrlAvailable(url) 
{
    return new Promise((resolve) => {
        const request = http.get(url, (res) => 
        {
            if (res.statusCode === 200) 
            {
                resolve(true);
            } 
            else 
            {
                resolve(false);
            }
            res.destroy();
        });

        request.on('error', () => {
            resolve(false);
        });

        request.end();
    });
}

async function connectWithRetry(url, maxRetries = 10, delay = 1000) 
{
    for (let i = 0; i < maxRetries; i++) 
    {
        console.log(`Attempt ${i+1} to connect to ${url}`);
        const available = await isUrlAvailable(url);

        if (available) 
        {
            console.log('Connection successful!');
            return true;
        }

        console.log(`Connection failed, retrying in ${delay}ms...`);
        await new Promise(resolve => setTimeout(resolve, delay));
    }

    console.log('Max retries reached, giving up.');
    return false;
}

async function createWindow() 
{
    mainWindow = new BrowserWindow({
        width: 1280,
        height: 720,
        webPreferences: 
        {
            nodeIntegration: true,
            contextIsolation: false
        }
    });

    // Check if we're in development or production
    const isDev = !app.isPackaged;

    if (isDev) 
    {
        console.log('Running in development mode, connecting to Astro dev server...');

        // Try to connect to the Astro dev server
        const devServerUrl = 'http://localhost:4321';
        const connected = await connectWithRetry(devServerUrl);

        if (connected) 
        {
            mainWindow.loadURL(devServerUrl);
            mainWindow.webContents.openDevTools();
        } 
        else 
        {
            // Show error screen
            mainWindow.loadFile(path.join(__dirname, 'error.html'));
        }
    } 
    else
    {
        // In production: load from built files
        const indexPath = path.join(__dirname, '../dist/index.html');
        console.log(`Running in production mode, loading from: ${indexPath}`);
        mainWindow.loadFile(indexPath);
    }
}

app.whenReady().then(() => {
    createWindow();
});

app.on('window-all-closed', () => {
    if (process.platform !== 'darwin') { app.quit(); }
});

app.on('activate', () => {
    if (BrowserWindow.getAllWindows().length === 0) { createWindow(); }
});

