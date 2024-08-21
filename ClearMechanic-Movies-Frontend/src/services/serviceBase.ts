import axios, { AxiosInstance, InternalAxiosRequestConfig, AxiosResponse } from "axios";
import { getEnv } from "../helpers/envHelpers";

const movieApiUrl = getEnv("MOVIE_API");

export default abstract class ServiceBase {
    protected readonly client: AxiosInstance;

    constructor(baseURL: string = movieApiUrl) {
        this.client = axios.create({
            baseURL,
            headers: {
                'Content-Type': 'application/json',
            },
        });

        this.client.interceptors.request.use(
            this.handleRequest.bind(this),
            this.handleError
        );

        this.client.interceptors.response.use(
            this.handleResponse,
            this.handleError
        );
    }

    protected handleRequest(config: InternalAxiosRequestConfig): InternalAxiosRequestConfig | Promise<InternalAxiosRequestConfig> {
        return config;
    }

    protected handleResponse(response: AxiosResponse): AxiosResponse {
        return response;
    }

    protected handleError(error: unknown): Promise<unknown> {
        return Promise.reject(error);
    }
}

export interface IResult<T> {
    isSuccess: boolean,
    statusCode: number,
    errors: string[],
    data: T
}