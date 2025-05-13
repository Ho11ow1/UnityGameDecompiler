const { contextBridge, ipcRenderer } = require('electron');
const path = require('path');

contextBridge.exposeInMainWorld('electronAPI', {
    selectFile: () => ipcRenderer.invoke('dialog:openFile'),
    path: {
        dirname: (filePath) => path.dirname(filePath),
        basename: (filePath) => path.basename(filePath),
    },
    getFileIcon: (filePath) => ipcRenderer.invoke('file:getIcon', filePath),
    // Seperator
    selectDirectory: () => ipcRenderer.invoke('dialog:setDirectory'),
    // Seperator
    decompile: (filePath, outputPath) => ipcRenderer.invoke('decompile:exe', filePath, outputPath)
});