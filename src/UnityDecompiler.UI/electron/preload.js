const { contextBridge, ipcRenderer } = require('electron');
const path = require('path');

contextBridge.exposeInMainWorld('electronAPI', {
    selectFile: () => ipcRenderer.invoke('dialog:openFile'),
    path: {
        dirname: (filePath) => path.dirname(filePath) + path.sep,
        basename: (filePath) => path.basename(filePath),
    }
});