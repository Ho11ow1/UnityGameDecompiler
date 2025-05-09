// @ts-check
import { defineConfig } from 'astro/config';

// https://astro.build/config
export default defineConfig({
    vite: 
    {
        resolve: 
        {
            alias: 
            {
                '@pages': '/src/pages',
                '@components': '/src/components',
                '@styles': '/src/styles',
                '@layouts': '/src/layouts',
            },
        },
    },
});
