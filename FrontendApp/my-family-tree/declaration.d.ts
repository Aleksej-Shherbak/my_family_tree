// this is necessary if you want to use scss/css modules with typescript 
// see more details here https://stackoverflow.com/questions/40382842/cant-import-css-scss-modules-typescript-says-cannot-find-module
declare module '*.scss' {
    const content: Record<string, string>;
    export default content;
}