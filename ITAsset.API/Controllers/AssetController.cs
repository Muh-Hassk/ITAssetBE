using ITAsset.core.Data;
using ITAsset.core.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ITAsset.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AssetController : ControllerBase
    {
        private readonly IAssetService _assetService;

        public AssetController(IAssetService assetService)
        {
            _assetService = assetService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsset(Asset asset)
        {
            asset.CreatedDate = DateTime.Now;
            await _assetService.CreateAsset(asset);
            var response = new
            {
                Status = "Success",
                Message = "Asset created successfully."
            };
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAssets()
        {
            var assets = await _assetService.GetAllAssets();
           
            return Ok(assets);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsset(int id)
        {
            await _assetService.DeleteAsset(id);
            var response = new
            {
                Status = "Success",
                Message = "Asset deleted successfully."
            };
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsset(Asset asset)
        {
            await _assetService.UpdateAsset(asset);
            var response = new
            {
                Status = "Success",
                Message = "Asset updated successfully."
            };
            return Ok(response);
        }
    }
}
