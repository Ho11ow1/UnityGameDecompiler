const fileNameS = document.querySelector('#file-name span');
const fileDirS = document.querySelector('#file-directory span');
const filePathS = document.querySelector('#file-path span');
const iconImg = document.getElementById('file-icon');
const outputPathS = document.querySelector('#output-dir span');

document.getElementById('select-file-btn').addEventListener('click', async () => {
    const filePath = await window.electronAPI.selectFile();

    if (!filePath) { return; }

    fileNameS.textContent = filePath ? window.electronAPI.path.basename(filePath) : 'No file selected';
    fileDirS.textContent = filePath ? window.electronAPI.path.dirname(filePath) : 'No directory selected';
    filePathS.textContent = filePath ? filePath : 'No file selected';

    const iconDataURL = await window.electronAPI.getFileIcon(filePath);
    if (iconDataURL) {
        iconImg.style.setProperty('--file-icon', `url("${iconDataURL}")`);
    }
});

document.getElementById('select-dir-btn').addEventListener('click', async() => {
    const dirPath = await window.electronAPI.selectDirectory();

    if(!dirPath) { return; }

    outputPathS.textContent = dirPath ? window.electronAPI.directory.dir(dirPath) : 'No directory selected';
})

// const decompileBtn = document.getElementById('decompile-btn');
// decompileBtn.addEventListener('click', async () => {
// });