import { spawn } from 'child_process';
import { join } from 'path';

function decompileGame(gamePath, outputPath)
{
    // Path to your compiled decompiler executable
    const decompilerPath = join(__dirname, '../../UnityDecompiler.exe');

    // Spawn the process
    const process = spawn(decompilerPath, [
        'decompile',
        '--input', gamePath,
        '--output', outputPath
    ]);

    // Handle process events
    // ...
}