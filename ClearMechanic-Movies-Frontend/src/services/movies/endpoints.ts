import { queryString } from "../../helpers/endpointHelpers";

export interface IGetPageParamas extends Record<string, string | number | boolean> {
    offset: string,
    limit: string,
    actor: string,
    genre: string,
    title: string
}

export const MoviesEndpoints = {
    getPage: (params?: IGetPageParamas) => {
        const query = params ? queryString(params) : '';
        return `/Movies${query ? `?${query}` : ''}`;
    }
}
