using System;
using System.Collections.Generic;
using ClientRegistration.BusinessLogic.Interfaces;
using ClientRegistration.Data.Entities;
using ClientRegistration.ViewModels.ViewModels;
using ClientRegistration.Repository.Repository;
using System.Linq;

namespace ClientRegistration.BusinessLogic.Logic
{
    public class VendorBusinessLogic : IVendorBusinessLogic
    {
        public static Vendor ConvertToVendor(VendorViewModel model)
        {
            var vendor = new Vendor
            {
                vendorId = model.vendorId,
                VendorEmail = model.VendorEmail,
                RegistrationDate = model.RegistrationDate,
                TelephoneNumber = model.TelephoneNumber,
                PostalAddress = model.PostalAddress,
                VendorRegNo = model.VendorRegNo,
                VendorName = model.VendorName
            };
            return vendor;
        }

        public void Insert(VendorViewModel model)
        {
            using (var db = new VendorRepository())
            {
                db.Insert(ConvertToVendor(model));
            }
        }

        public void Delete(VendorViewModel model)
        {
            using (var db=new VendorRepository())
            {
                db.Delete(ConvertToVendor(model));
            }
        }

        public IEnumerable<VendorViewModel> GetAllVendorsByBusinessAdmin(string BusinessAdminId)
        {
            using (var db = new VendorRepository())
            {
                return db.GetAll().Select(model => new VendorViewModel
                {
                    vendorId = model.vendorId,
                    VendorEmail = model.VendorEmail,
                    RegistrationDate = model.RegistrationDate,
                    TelephoneNumber = model.TelephoneNumber,
                    PostalAddress = model.PostalAddress,
                    VendorRegNo = model.VendorRegNo,
                    VendorName = model.VendorName

                }).Where(x => x.BusAdminId.Equals(BusinessAdminId));
            }
        }

        public VendorViewModel GetById(int VendorId)
        {
            using (var db = new VendorRepository())
            {
                var vendordbRes = db.GetAll().ToList().Find(d => (d.vendorId.Equals(VendorId)));

                var vendorview = new VendorViewModel();
                {
                    vendorview.vendorId = vendordbRes.vendorId;
                    vendorview.VendorEmail = vendordbRes.VendorEmail;
                    vendorview.RegistrationDate = vendordbRes.RegistrationDate;
                    vendorview.TelephoneNumber = vendordbRes.TelephoneNumber;
                    vendorview.PostalAddress = vendordbRes.PostalAddress;
                    vendorview.VendorRegNo = vendordbRes.VendorRegNo;
                    vendorview.VendorName = vendordbRes.VendorName;
                }
                return vendorview;

            }
        }

        public void Update(VendorViewModel model)
        {
            using (var db=new VendorRepository())
            {
                db.Update(ConvertToVendor(model));
            }
        }
    }
}
