const fileNameSpan = document.querySelector('#file-name span');
const fileDirSpan = document.querySelector('#file-directory span');
const filePathSpan = document.querySelector('#file-path span');

document.getElementById('select-file-btn').addEventListener('click', async () => {
    const filePath = await window.electronAPI.selectFile();

    console.log('File name:', filePath ? window.electronAPI.path.basename(filePath) : null);
    fileNameSpan.textContent = filePath ? window.electronAPI.path.basename(filePath) : 'No file selected';

    console.log('Directory path:', filePath ? window.electronAPI.path.dirname(filePath) : null);
    fileDirSpan.textContent = filePath ? window.electronAPI.path.dirname(filePath) : 'No directory selected';

    console.log('Selected file path:', filePath);
    filePathSpan.textContent = filePath ? filePath : 'No file selected';
});

// const decompileBtn = document.getElementById('decompile-btn');
// decompileBtn.addEventListener('click', async () => {
// });