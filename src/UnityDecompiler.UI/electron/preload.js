const { contextBridge, ipcRenderer } = require('electron');
const path = require('path');

contextBridge.exposeInMainWorld('electronAPI', {
    selectFile: () => ipcRenderer.invoke('dialog:openFile'),
    path: {
<<<<<<< HEAD
        dirname: (filePath) => path.dirname(filePath) + path.sep,
        basename: (filePath) => path.basename(filePath),
    }
=======
        dirname: (filePath) => path.dirname(filePath),
        basename: (filePath) => path.basename(filePath),
    },
    getFileIcon: (filePath) => ipcRenderer.invoke('file:getIcon', filePath),
    // Seperator
    selectDirectory: () => ipcRenderer.invoke('dialog:setDirectory'),
    // Seperator
    decompile: (filePath, folderPath, outputPath) => ipcRenderer.invoke('decompile:exe', filePath, folderPath, outputPath)
>>>>>>> 734af300c8fc09b81d4555d2faf4551750e05087
});