using IntranetDataAccessLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.Xml;
using TuraProductsAPI.Models.Shipments;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TuraProductsAPI.Controllers.V1.Intranet.Logistics.Shipments
{
    [Route("api/v1/intranet/logistics/shipments/[controller]")]
    [ApiController]
    public class ShipmentsController : ControllerBase
    {
        // GET: api/<ShipmentsController>
        [HttpGet]
        public async Task<ActionResult<List<ShipmentModel>>> Get()
        {
            List<ShipmentModel> shipmentModels = new();

            try
            {
                using (var context = new IntranetDataAccessLibrary.Context.ItturaContext())
                {
                    var shipments = await context.Shipments.OrderByDescending(x => x.Id).Take(100).ToListAsync();

                    foreach (var shipment in shipments)
                    {
                        ShipmentModel shipmentModel = new()
                        {
                            Shipment = new Models.Shipments.ShipmentData
                            {
                                Id = shipment.Id,
                                ReceivedAt = shipment.ReceivedAt,
                                ReceivedBy = shipment.ReceivedBy,
                                ReceivingCompany = shipment.ReceivingCompany,
                                OrderNumbers = shipment.OrderNumbers,
                                NumberOfPallets = shipment.NumberOfPallets,
                                NumberOfPackages = shipment.NumberOfPackages,
                                Placement = shipment.Placement,
                                InitatedBy = shipment.InitatedBy,
                                Supplier = shipment.Supplier,
                                Prioritized = shipment.Prioritized
                            }
                        };

                        //var shipmentUpdate = await context.ShipmentUpdates.Where(x => x.ShipmentId == shipment.Id).OrderByDescending(x => x.UpdatedAt).FirstOrDefaultAsync();
                        List<ShipmentUpdateData> shipmentUpdateDatas = new();
                        var shipmentUpdates = await context.ShipmentUpdates.Where(x => x.ShipmentId == shipment.Id).ToListAsync();
                        var shipmentUpdate = shipmentUpdates.OrderByDescending(x => x.UpdatedAt).FirstOrDefault();

                        if (shipmentUpdate != null)
                        {
                            shipmentModel.ShipmentUpdate = new()
                            {
                                Id = shipmentUpdate.Id,
                                UpdatedAt = shipmentUpdate.UpdatedAt,
                                UpdatedBy = shipmentUpdate.UpdatedBy,
                                ShipmentId = shipmentUpdate.ShipmentId,
                                Note = shipmentUpdate.Note,
                                StatusId = shipmentUpdate.StatusId
                            };

                            foreach(var update in shipmentUpdates)
                            {
                                var updateModel = new ShipmentUpdateData
                                {
                                    Id = update.Id,
                                    UpdatedAt = update.UpdatedAt,
                                    UpdatedBy = update.UpdatedBy,
                                    ShipmentId = update.ShipmentId,
                                    Note = update.Note,
                                    StatusId = update.StatusId
                                };

                                shipmentUpdateDatas.Add(updateModel);
                            }

                            shipmentModel.ShipmentUpdates = shipmentUpdateDatas;

                            if (shipmentUpdate.StatusId != 4)
                            {
                                var shipmentDeviation = await context.ShipmentDeviations.Where(x => x.ShipmentId == shipment.Id).FirstOrDefaultAsync();

                                if (shipmentDeviation != null)
                                {
                                    shipmentModel.ShipmentDeviation = new()
                                    {
                                        ShipmentId = shipmentDeviation.ShipmentId,
                                        DamagedGoods = shipmentDeviation.DamagedGoods,
                                        AcceptablePallets = shipmentDeviation.AcceptablePallets,
                                        CorrectPalletHeight = shipmentDeviation.CorrectPalletHeight,
                                        HasDeliveryNote = shipmentDeviation.HasDeliveryNote,
                                        OrderNumberOnDeliveryNote = shipmentDeviation.OrderNumberOnDeliveryNote,
                                        ConcealedFreigtDamage = shipmentDeviation.ConcealedFreigtDamage,
                                        SortedBoxwise = shipmentDeviation.SortedBoxwise,
                                        TaggedMixedBoxes = shipmentDeviation.TaggedMixedBoxes,
                                        Note = shipmentDeviation.Note
                                    };
                                }

                                shipmentModels.Add(shipmentModel);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

            return shipmentModels;
        }

        // POST api/<ShipmentsController>
        [HttpPost]
        public void Post([FromBody] ShipmentModel shipmentModel)
        {

        }

        // PUT api/<ShipmentsController>/5
        [HttpPut]
        public async Task Put([FromBody] ShipmentModel shipmentModel)
        {
            try
            {
                using (var context = new IntranetDataAccessLibrary.Context.ItturaContext())
                {
                    var shipment = await context.Shipments.Where(x => x.Id == shipmentModel.Shipment.Id).FirstOrDefaultAsync();

                    if (shipment != null)
                    {
                        shipment.ReceivedBy = shipmentModel.Shipment.ReceivedBy;
                        shipment.ReceivingCompany = shipmentModel.Shipment.ReceivingCompany;
                        shipment.Supplier = shipmentModel.Shipment.Supplier;
                        shipment.OrderNumbers = shipmentModel.Shipment.OrderNumbers;
                        shipment.NumberOfPallets = shipmentModel.Shipment.NumberOfPallets;
                        shipment.NumberOfPackages = shipmentModel.Shipment.NumberOfPackages;
                        shipment.Placement = shipmentModel.Shipment.Placement;
                        shipment.Prioritized = shipmentModel.Shipment.Prioritized;

                        //await context.ShipmentUpdates.AddAsync(new ShipmentUpdate()
                        //{
                        //    ShipmentId = shipmentModel.ShipmentUpdate.ShipmentId,
                        //    UpdatedBy = shipmentModel.ShipmentUpdate.UpdatedBy,
                        //    UpdatedAt = shipmentModel.ShipmentUpdate.UpdatedAt,
                        //    StatusId = shipmentModel.ShipmentUpdate.StatusId,
                        //    Note = shipmentModel.ShipmentUpdate.Note
                        //});

                        context.Update(shipment);
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        // DELETE api/<ShipmentsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
