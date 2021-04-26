export interface GlobalAleart {
    Message: string,
    GlobalAleartType : GlobalAleartTypes
}

export enum GlobalAleartTypes{
    Info,
    Danger,
    Warning,
    Success
}

