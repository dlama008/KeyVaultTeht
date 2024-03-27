using KeyVaultExample.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyVaultController
{
    public class KeyVaultController : ControllerBase
    {
        private readonly ILogger<KeyVaultController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IKeyVaultSecretManager _keyVaultSecretManager;
       

        public KeyVaultController(ILogger<KeyVaultController> logger, IConfiguration configuration, IKeyVaultSecretManager keyVaultSecretManager)
        {
            _logger = logger;
            _configuration = configuration;
            _keyVaultSecretManager = keyVaultSecretManager;
        }

        [HttpGet("GetKeyVaultSecrets")]
        public async Task<IActionResult> GetKeyVaultSecret(string secret)
        {
            var response = await _keyVaultSecretManager.GetSecretAsync(secret);
            return Ok(response);
        }
    
        [HttpGet("GetKeyVaultSecretFromConfiguration")]
        public async Task<IActionResult> GetKeyVaultSecretFromConfiguration(string secret)
        {
            var response = _configuration[secret];
            return Ok(response);
        }
    }
}
