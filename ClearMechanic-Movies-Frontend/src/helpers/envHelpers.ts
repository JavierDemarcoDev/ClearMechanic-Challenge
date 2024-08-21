export const getEnv: (_env: string) => string = (env) => {
    const value = import.meta.env[`VITE_${env}`];

    if (!value) {
        throw new Error(`Environment variable ${env} is not defined`);
    }

    return value;
};
