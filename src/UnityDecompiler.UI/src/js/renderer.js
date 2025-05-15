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

    outputPathS.textContent = dirPath ? dirPath : 'No directory selected';
})

document.getElementById('decompile-btn').addEventListener('click', async () => {
    const filePath = filePathS.textContent;
    const folderPath = fileDirS.textContent;
    const outputPath = outputPathS.textContent;

    if (!filePath || !outputPath) 
    {
        alert('Please select a file and an output directory.');
        return;
    }
    const btn = document.getElementById('decompile-btn');
    const btnH3 = document.querySelector('#decompile-btn h3');

    btn.disabled = true;
    btnH3.textContent = 'Decompiling...';

    await window.electronAPI.decompile(filePath, folderPath, outputPath);

    btn.disabled = false;
    btnH3.textContent = 'Decompile';
});

