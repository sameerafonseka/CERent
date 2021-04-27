import { ProductDto } from "./ProductDto";

export interface CartItem {
    product: ProductDto,
    noOfDays: number,
}
