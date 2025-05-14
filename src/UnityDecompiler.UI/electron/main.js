const { app, BrowserWindow, ipcMain, dialog } = require('electron')
<<<<<<< HEAD
=======
const { execFile } = require('child_process');
>>>>>>> 734af300c8fc09b81d4555d2faf4551750e05087
const path = require('node:path')

const createWindow = () => {
    const window = new BrowserWindow({
        title: "Unity game decompiler",
        icon: path.join(__dirname, '../public/icon.png'),
<<<<<<< HEAD
        width: 498,
        height: 720,
=======
        width: 600,
        height: 1080,
>>>>>>> 734af300c8fc09b81d4555d2faf4551750e05087
        resizable: false,
        autoHideMenuBar: true,
        webPreferences: {
            preload: path.join(__dirname, 'preload.js'),
            sandbox: false,
            contextIsolation: true
        }
    })

    window.loadFile(path.join(__dirname, '../index.html'))
    // window.webContents.openDevTools()
}

// ==================== HANDLERS ====================
<<<<<<< HEAD

ipcMain.handle('dialog:openFile', async () => {
    const { canceled, filePaths } = await dialog.showOpenDialog({
        title: 'Select an EXE file',
        properties: ['openFile'],
        filters: [
            { name: 'Executable Files', extensions: ['exe'] }
        ]
    });

    return canceled ? null : filePaths[0];
});
=======
>>>>>>> 734af300c8fc09b81d4555d2faf4551750e05087

app.whenReady().then(() => {
    createWindow()
})

app.on('window-all-closed', () => {
    if (process.platform !== 'darwin') {
        app.quit()
    }
})
<<<<<<< HEAD
=======

ipcMain.handle('dialog:openFile', async () => {
    const { canceled, filePaths } = await dialog.showOpenDialog({
        title: 'Select an EXE file',
        properties: ['openFile'],
        filters: [
            { name: 'Executable Files', extensions: ['exe'] }
        ]
    });

    return canceled ? null : filePaths[0];
});

ipcMain.handle('file:getIcon', async (event, filePath) => {
    try {
        const icon = await app.getFileIcon(filePath, { size: 'normal' });
        return icon.toDataURL();
    } 
    catch (err) {
        console.error('Failed to get file icon:', err);
        return null;
    }
});
>>>>>>> 734af300c8fc09b81d4555d2faf4551750e05087

ipcMain.handle('dialog:setDirectory', async () => {
    const { canceled, filePaths } = await dialog.showOpenDialog({
        title: 'Select output directory',
        properties: ['openDirectory'],
    });

    return canceled ? null : filePaths[0];
});

ipcMain.handle('decompile:exe', async (event, filePath, folderPath, outputPath) => {
    const decompilerPath = path.join(__dirname, '../../UnityDecompiler.CLI/bin/Debug/net8.0/UnityDecompiler.CLI.exe');
    const args = [filePath, folderPath, outputPath];

    // execFile(decompilerPath, args);
    execFile(decompilerPath, args, (error, stdout, stderr) => {
        if (error) {
            console.error(`Error: ${error.message}`);
            return;
        }
        if (stderr) {
            console.error(`stderr: ${stderr}`);
            return;
        }
        console.log(`stdout: ${stdout}`);
    });
})