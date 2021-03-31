export class Product {
  constructor(
    public productId?: number, // '?' stand for Optional
    public productName?: string,
    public category?: string,
    public description?: string,
    public price?: number
  ) { }
}
