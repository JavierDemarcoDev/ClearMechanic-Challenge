import { AxiosResponse } from "axios";

import { IMovie } from "../../redux/reducers/movies";
import ServiceBase, { IResult } from "../serviceBase";
import { IGetPageParamas, MoviesEndpoints } from "./endpoints";
import { IPagination } from "../../redux/store";

class Service extends ServiceBase {

    async getMovies(params?: IGetPageParamas): Promise<AxiosResponse<IResult<IPagination<IMovie>>>> {
        const url = MoviesEndpoints.getPage(params);
        return await this.client.get(url);
    }
}

export const MovieService = new Service();