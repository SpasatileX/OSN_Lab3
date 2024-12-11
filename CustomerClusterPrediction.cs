using Microsoft.ML.Data;

namespace Lab3;

public class CustomerClusterPrediction
{
    [ColumnName("PredictedLabel")]
    public uint PredictedClusterId { get; set; }

    [ColumnName("Score")]
    public float[] Score { get; set; }
}
