using System.ComponentModel;

namespace QuantumGate.CommonPackages
{
    /// <summary>
    /// Possible reponse messages
    /// </summary>
    public enum ResponseMessage
    {
        [Description("Success")]
        Success,
        /// <summary>
        /// Response message for failure
        /// </summary>
        [Description("Exception")]
        Exception,
        /// <summary>
        /// Response message for other erros
        /// </summary>
        [Description("Error")]
        MiscError,
        /// <summary>
        /// Response message for data not found
        /// </summary>
        [Description("Data not found.")]
        DataNotFound
    }
}
