namespace CDNApplication.Data.Services
{
    using System.Threading.Tasks;
    using Microsoft.Azure.KeyVault;
    using Microsoft.Azure.KeyVault.Models;
    using Microsoft.Azure.Services.AppAuthentication;
    using Microsoft.Rest.Azure;

    /// <summary>
    ///  Represents the Azure key vault service.
    /// </summary>
    public class AzureKeyVaultService
    {
        private string dNs;

        /// <summary>
        /// Initializes a new instance of the <see cref="AzureKeyVaultService"/> class.
        /// </summary>
        /// <param name="dNS">DNS for the key vault.</param>
        public AzureKeyVaultService(string dNS)
        {
            this.dNs = dNS;
        }

        /// <summary>
        /// Gets a secret from azure key vault.
        /// </summary>
        /// <param name="secretName">Secret to get.</param>
        /// <returns>Secret value.</returns>
        public string GetSecret(string secretName)
        {
            using (var keyVaultClient = GetKeyVaultClient())
            {
                var sercret = keyVaultClient.GetSecretAsync(vaultBaseUrl: this.dNs, secretName: secretName).ConfigureAwait(true).GetAwaiter().GetResult();

                return sercret.Value;
            }
        }

        /// <summary>
        /// Get a list of secrets from the azure key vault.
        /// </summary>
        /// <returns>List of secrets.</returns>
        public IPage<SecretItem> GetListOfSecretsAsync()
        {
            using (var keyVaultClient = GetKeyVaultClient())
            {
                var sercrets = keyVaultClient.GetSecretsAsync(vaultBaseUrl: this.dNs).ConfigureAwait(true).GetAwaiter().GetResult();

                return sercrets;
            }
        }

        /// <summary>
        /// Get the key vault client.
        /// </summary>
        /// <returns>Key vault client.</returns>
        private static KeyVaultClient GetKeyVaultClient()
        {
            var azureServiceTokenProvider = new AzureServiceTokenProvider();

            var keyVaultClient = new KeyVaultClient(
                        new KeyVaultClient.AuthenticationCallback(
                            azureServiceTokenProvider.KeyVaultTokenCallback));

            return keyVaultClient;
        }
    }
}
