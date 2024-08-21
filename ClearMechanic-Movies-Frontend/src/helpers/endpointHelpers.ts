export const queryString = (queryObj: Record<string, string | number | boolean | undefined>): string => {
    const queryString = Object.keys(queryObj)
        .filter(key => {
            const value = queryObj[key];
            return value !== '' && value !== undefined;
        })
        .map(key => {
            const value = queryObj[key];
            return `${encodeURIComponent(key)}=${encodeURIComponent(String(value))}`;
        })
        .join("&");

    return queryString;
};
