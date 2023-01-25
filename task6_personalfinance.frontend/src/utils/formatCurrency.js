export const currencyFormatter = new Intl.NumberFormat(undefined, {
    currency: "eur",
    style: "currency",
    minimumFractionDigits: 0
})

export function formatCurrency(number) {
    return currencyFormatter.format(number);
}