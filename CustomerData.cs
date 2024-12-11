using Microsoft.ML.Data;

namespace Lab3;

public class CustomerData
{
    [LoadColumn(0)] public string CUST_ID { get; set; }
    [LoadColumn(1)] public float BALANCE { get; set; }
    [LoadColumn(2)] public float BALANCE_FREQUENCY { get; set; }
    [LoadColumn(3)] public float PURCHASES { get; set; }
    [LoadColumn(4)] public float ONEOFF_PURCHASES { get; set; }
    [LoadColumn(5)] public float INSTALLMENTS_PURCHASES { get; set; }
    [LoadColumn(6)] public float CASH_ADVANCE { get; set; }
    [LoadColumn(7)] public float PURCHASES_FREQUENCY { get; set; }
    [LoadColumn(8)] public float ONEOFF_PURCHASES_FREQUENCY { get; set; }
    [LoadColumn(9)] public float PURCHASES_INSTALLMENTS_FREQUENCY { get; set; }
    [LoadColumn(10)] public float CASH_ADVANCE_FREQUENCY { get; set; }
    [LoadColumn(11)] public float CASH_ADVANCE_TRX { get; set; }
    [LoadColumn(12)] public float PURCHASES_TRX { get; set; }
    [LoadColumn(13)] public float CREDIT_LIMIT { get; set; }
    [LoadColumn(14)] public float PAYMENTS { get; set; }
    [LoadColumn(15)] public float MINIMUM_PAYMENTS { get; set; }
    [LoadColumn(16)] public float PRC_FULL_PAYMENT { get; set; }
    [LoadColumn(17)] public float TENURE { get; set; }
}
