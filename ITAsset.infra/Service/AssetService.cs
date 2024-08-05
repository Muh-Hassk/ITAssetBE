using ITAsset.core.Data;
using ITAsset.core.IRepository;
using ITAsset.core.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITAsset.infra.Service
{
    public class AssetService : IAssetService
    {
        private readonly IAssetRepository _assetRepository;

        public AssetService(IAssetRepository assetRepository)
        {
            _assetRepository = assetRepository;
        }

        public async Task CreateAsset(Asset asset)
        {
            await _assetRepository.CreateAsset(asset);
        }

        public async Task DeleteAsset(int id)
        {
            await _assetRepository.DeleteAsset(id);
        }

        public Task<List<Asset>> GetAllAssets()
        {
            var res = _assetRepository.GetAllAssets();

            return res;
        }

        public async Task UpdateAsset(Asset asset)
        {
            await _assetRepository.UpdateAsset(asset);

        }
    }
}

