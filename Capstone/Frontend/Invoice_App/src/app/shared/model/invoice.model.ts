export interface Invoice {
    invoiceID: number;
    invoiceNumber: string;
    invoiceDate: string;
    vendorID: number;
    customerID: number;
    totalAmount: number;
    currencyID: number;
  }