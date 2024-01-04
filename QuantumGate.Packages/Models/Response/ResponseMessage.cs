using System.ComponentModel;

namespace QuantumGate.Packages.Models
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
    }
}
