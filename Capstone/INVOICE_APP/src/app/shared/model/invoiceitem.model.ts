export interface InvoiceItem {
    itemID: number;
    invoiceID: number;
    productID: number;
    quantity: number;
    unitPrice: number; 
    taxID: number;
    discount: number;
    lineTotal: number;
  }