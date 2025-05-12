const { app, BrowserWindow, ipcMain, dialog } = require('electron')
const path = require('node:path')

const createWindow = () => {
    const window = new BrowserWindow({
        title: "Unity game decompiler",
        icon: path.join(__dirname, '../public/icon.png'),
        width: 600,
        height: 900,
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

app.whenReady().then(() => {
    createWindow()
})

app.on('window-all-closed', () => {
    if (process.platform !== 'darwin') {
        app.quit()
    }
})

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

ipcMain.handle('dialog:setDirectory', async () => {
    const { canceled, filePaths } = await dialog.showOpenDialog({
        title: 'Select output directory',
        properties: ['openDirectory'],
    });

    return canceled ? null : filePaths[0];
});