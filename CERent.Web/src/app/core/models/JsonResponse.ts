export interface JsonResponse<T extends object | null>  {
    status: string,
    data: T,
    code: string,
    message: string

}
