using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AMC_Tracker.Models;
using AMC_Tracker.DAL;


namespace AMC_Tracker.Controllers
{
    public class ContractController : Controller
    {

        Contract_DAL _contractDAL = new Contract_DAL();
        // GET: Contract
        public ActionResult Index(string SearchBy, string SearchValue)
        {
            var contractList = _contractDAL.GetAllContracts();

            if (contractList.Count == 0)
            {
                TempData["InfoMessage"] = "Currently products not available in the database. ";
            }
            else
            {
                if (string.IsNullOrEmpty(SearchValue))
                {
                   
                    return View(contractList);
                }
                else
                {
                    if (SearchBy.ToLower() == "vendorname")
                    {
                        var SearchByVendorName = contractList.Where(p => p.VendorName.ToLower().Contains(SearchValue.ToLower()));
                        return View(SearchByVendorName);
                    }
                    else if (SearchBy.ToLower() == "contractnumber")
                    {
                        var SearchByContractNumber = contractList.Where(p => p.ContractNumber == int.Parse(SearchValue));
                        return View(SearchByContractNumber);
                    }
                    else if (SearchBy.ToLower() == "vendormobilenumber")
                    {
                        var SearchByVendorMobileNumber = contractList.Where(p => p.VendorMobileNumber.ToLower().Contains(SearchValue.ToLower()));
                        return View(SearchByVendorMobileNumber);
                    }
                    else if (SearchBy.ToLower() == "dateofcontract")
                    {
                        var SearchByDateOfContract = contractList.Where(p => p.DateOfContract.ToLower().Contains(SearchValue.ToLower()));
                        return View(SearchByDateOfContract);
                    }
                }
            }
            return View(contractList);
        }

        // GET: Contract/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                var contract = _contractDAL.GetContractByID(id).FirstOrDefault();

                if (contract == null)
                {
                    TempData["InfoMessage"] = "Contract not available with id " + id.ToString();
                    return RedirectToAction("Index");
                }
                return View(contract);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View();

            }
        }

        // GET: Contract/Create

        public ActionResult Create()
        {
            var AmcTypeList = new List<string>() { "Comprehensive", "Non-Comprehensive", "Max Power Contract", "Operation and Maintainance" };
            var BudgetTypeList = new List<string>() { "Capital", "Revenue", "Miscellaneous" };
            var PaymentTypeList = new List<string>() { "Monthly", "Quaterly", "Half Yearly", "Annualy" };
            var ServiceTypeList = new List<string>() { "Yes", "No" };
            ViewBag.AmcTypeList = AmcTypeList;
            ViewBag.BudgetTypeList = BudgetTypeList;
            ViewBag.PaymentTypeList = PaymentTypeList;
            ViewBag.ServiceTypeList = ServiceTypeList;
            return View();
        }

        // POST: Contract/Create
        [HttpPost]
        public ActionResult Create(Contract contract)
        {
            bool IsInserted = false;
            try
            {
                if (ModelState.IsValid)
                {
                    IsInserted = _contractDAL.InsertContract(contract);


                    if (IsInserted)
                    {
                        TempData["SuccessMessage"] = "Contract details saved successfully....!";
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Contract is already available/Unable to save contract details";
                    }
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View();
            }
        }

        // GET: Contract/Edit/5
        public ActionResult Edit(int id)
        {
            var contracts = _contractDAL.GetContractByID(id).FirstOrDefault();

            if (contracts == null)
            {
                TempData["InfoMessage"] = "Contract not available with ID " + id.ToString();
                return RedirectToAction("Index");
            }
            return View(contracts);
        }

        // POST: Contract/Edit/5
        [HttpPost, ActionName("Edit")]
        public ActionResult UpdateContract(Contract contract)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    bool IsUpdated = _contractDAL.UpdateContract(contract);

                    if (IsUpdated)
                    {
                        TempData["SuccessMessage"] = "Contract details updated successfully....!";

                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Contract is already available/Unable to save contract details";

                    }


                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View();
            }
        }
        // GET: Contract/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var contract = _contractDAL.GetContractByID(id).FirstOrDefault();

                if (contract == null)
                {
                    TempData["InfoMessage"] = "Contract not available with id " + id.ToString();
                    return RedirectToAction("Index");


                }
                return View(contract);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;

                return View();
            }
        }

        // POST: Contract/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmation(int id)
        {
            try
            {
                string result = _contractDAL.DeleteContract(id);

                if (result.Contains("deleted"))
                {
                    TempData["SuccessMessage"] = result;

                }
                else
                {
                    TempData["ErrorMessage"] = result;
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;

                return View();
            }


        }


    }
}
