using System;
using System.Linq;
using Microsoft.ML;
using Microsoft.ML.Transforms;

namespace Lab3;
class Program
{
    static void Main(string[] args)
    {
        MLContext mlContext = new MLContext();

        string dataPath = "../../../data.csv";
        var data = mlContext.Data.LoadFromTextFile<CustomerData>(dataPath, separatorChar: ',', hasHeader: true);

        var pipeline = mlContext.Transforms.Concatenate("Features",
                    nameof(CustomerData.BALANCE),
                    nameof(CustomerData.BALANCE_FREQUENCY),
                    nameof(CustomerData.PURCHASES),
                    nameof(CustomerData.ONEOFF_PURCHASES),
                    nameof(CustomerData.INSTALLMENTS_PURCHASES),
                    nameof(CustomerData.CASH_ADVANCE),
                    nameof(CustomerData.PURCHASES_FREQUENCY),
                    nameof(CustomerData.ONEOFF_PURCHASES_FREQUENCY),
                    nameof(CustomerData.PURCHASES_INSTALLMENTS_FREQUENCY),
                    nameof(CustomerData.CASH_ADVANCE_FREQUENCY),
                    nameof(CustomerData.CASH_ADVANCE_TRX),
                    nameof(CustomerData.PURCHASES_TRX),
                    nameof(CustomerData.CREDIT_LIMIT),
                    nameof(CustomerData.PAYMENTS),
                    nameof(CustomerData.MINIMUM_PAYMENTS),
                    nameof(CustomerData.PRC_FULL_PAYMENT),
                    nameof(CustomerData.TENURE))
            .Append(mlContext.Clustering.Trainers.KMeans("Features", numberOfClusters: 5));

        var model = pipeline.Fit(data);

        var predictions = model.Transform(data);

        var clusterPredictions = mlContext.Data.CreateEnumerable<CustomerClusterPrediction>(predictions, reuseRowObject: false).ToList();

        var clusterCounts = clusterPredictions.GroupBy(p => p.PredictedClusterId)
                                               .Select(group => new
                                               {
                                                   ClusterId = group.Key,
                                                   Count = group.Count()
                                               })
                                               .OrderBy(group => group.ClusterId)
                                               .ToList();

        foreach (var cluster in clusterCounts)
        {
            Console.WriteLine($"Cluster {cluster.ClusterId}: {cluster.Count} customers");
        }

        int totalCustomers = clusterPredictions.Count;
        Console.WriteLine($"Total number of customers: {totalCustomers}");
    }
}
