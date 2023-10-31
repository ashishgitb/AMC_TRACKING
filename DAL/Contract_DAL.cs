using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using AMC_Tracker.Models;

namespace AMC_Tracker.DAL
{
    public class Contract_DAL
    {
        string conString = ConfigurationManager.ConnectionStrings["AMCconnectionstring"].ToString();


        //GET ALL CONTRACTS

        public List<Contract> GetAllContracts()
        {
            List<Contract> contractList = new List<Contract>();

            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT ContractNumber, VendorName, VendorMobileNumber, VendorEmailId, DateOfContract, EndDate, RevisedAmount FROM dbo.details WITH (NOLOCK)";
                SqlDataAdapter sqlDA = new SqlDataAdapter(command);
                DataTable dtContracts = new DataTable();

                connection.Open();
                sqlDA.Fill(dtContracts);
                connection.Close();

                foreach (DataRow dr in dtContracts.Rows)
                {
                    contractList.Add(new Contract
                    {
                        ContractNumber = Convert.ToInt32(dr["ContractNumber"]),
                        VendorName = dr["VendorName"].ToString(),
                        VendorMobileNumber = dr["VendorMobileNumber"].ToString(),
                        VendorEmailId = dr["VendorEmailId"].ToString(),
                        DateOfContract = dr["DateOfContract"].ToString(),
                        EndDate = dr["EndDate"].ToString(),
                        RevisedAmount = dr["RevisedAmount"].ToString()
                    });
                }
            }

            return contractList;
        }


        //INSERT CONTRACTS

        public bool InsertContract(Contract contract)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "INSERT INTO dbo.details (ContractNumber, VendorName, VendorTelephoneNumber, VendorMobileNumber, VendorEmailId, DateOfContract, StartDate, EndDate, OriginalAmount, RevisedAmount, AmcType, BudgetType, PaymentType, ServiceType) " +
                    "VALUES (@ContractNumber, @VendorName, @VendorTelephoneNumber, @VendorMobileNumber, @VendorEmailId, @DateOfContract, @StartDate, @EndDate, @OriginalAmount, @RevisedAmount, @AmcType, @BudgetType, @PaymentType, @ServiceType)";

                command.Parameters.AddWithValue("@ContractNumber", contract.ContractNumber);
                command.Parameters.AddWithValue("@VendorName", contract.VendorName);
                command.Parameters.AddWithValue("@VendorTelephoneNumber", contract.VendorTelephoneNumber);
                command.Parameters.AddWithValue("@VendorMobileNumber", contract.VendorMobileNumber);
                command.Parameters.AddWithValue("@VendorEmailId", contract.VendorEmailId);
                command.Parameters.AddWithValue("@DateOfContract", contract.DateOfContract);
                command.Parameters.AddWithValue("@StartDate", contract.StartDate);
                command.Parameters.AddWithValue("@EndDate", contract.EndDate);
                command.Parameters.AddWithValue("@OriginalAmount", contract.OriginalAmount);
                command.Parameters.AddWithValue("@RevisedAmount", contract.RevisedAmount);
                command.Parameters.AddWithValue("@AmcType", contract.AmcType);
                command.Parameters.AddWithValue("@BudgetType", contract.BudgetType);
                command.Parameters.AddWithValue("@PaymentType", contract.PaymentType);
                command.Parameters.AddWithValue("@ServiceType", contract.ServiceType);

                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
                connection.Close();
            }

            return rowsAffected > 0;
        }



        //GET CONTRACTS BY CONTRACT NUMBER

        public List<Contract> GetContractByID(int ContractNumber)
        {
            List<Contract> contractList = new List<Contract>();

            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT ContractNumber, VendorName, VendorTelephoneNumber, VendorMobileNumber, VendorEmailId, DateOfContract, StartDate, EndDate, OriginalAmount, RevisedAmount, AmcType, BudgetType, PaymentType, ServiceType " +
                    "FROM dbo.details WHERE ContractNumber = @ContractNumber";
                command.Parameters.AddWithValue("@ContractNumber", ContractNumber);
                SqlDataAdapter sqlDA = new SqlDataAdapter(command);
                DataTable dtContracts = new DataTable();

                connection.Open();
                sqlDA.Fill(dtContracts);
                connection.Close();

                foreach (DataRow dr in dtContracts.Rows)
                {
                    contractList.Add(new Contract
                    {
                        ContractNumber = Convert.ToInt32(dr["ContractNumber"]),
                        VendorName = dr["VendorName"].ToString(),
                        VendorTelephoneNumber = dr["VendorTelephoneNumber"].ToString(),
                        VendorMobileNumber = dr["VendorMobileNumber"].ToString(),
                        VendorEmailId = dr["VendorEmailId"].ToString(),
                        DateOfContract = dr["DateOfContract"].ToString(),
                        StartDate = dr["StartDate"].ToString(),
                        EndDate = dr["EndDate"].ToString(),
                        OriginalAmount = dr["OriginalAmount"].ToString(),
                        RevisedAmount = dr["RevisedAmount"].ToString(),
                        AmcType = dr["AmcType"].ToString(),
                        BudgetType = dr["BudgetType"].ToString(),
                        PaymentType = dr["PaymentType"].ToString(),
                        ServiceType = dr["ServiceType"].ToString()
                    });
                }
            }

            return contractList;
        }


        //Update Product

        public bool UpdateContract(Contract contract)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "UPDATE dbo.details SET ContractNumber = @ContractNumber, VendorName = @VendorName, VendorTelephoneNumber = @VendorTelephoneNumber, " +
                    "VendorMobileNumber = @VendorMobileNumber, VendorEmailId = @VendorEmailId, DateOfContract = @DateOfContract, StartDate = @StartDate, " +
                    "EndDate = @EndDate, OriginalAmount = @OriginalAmount, RevisedAmount = @RevisedAmount, AmcType = @AmcType, BudgetType = @BudgetType, " +
                    "PaymentType = @PaymentType, ServiceType = @ServiceType WHERE ContractNumber = @ContractNumber";

                command.Parameters.AddWithValue("@ContractNumber", contract.ContractNumber);
                command.Parameters.AddWithValue("@VendorName", contract.VendorName);
                command.Parameters.AddWithValue("@VendorTelephoneNumber", contract.VendorTelephoneNumber);
                command.Parameters.AddWithValue("@VendorMobileNumber", contract.VendorMobileNumber);
                command.Parameters.AddWithValue("@VendorEmailId", contract.VendorEmailId);
                command.Parameters.AddWithValue("@DateOfContract", contract.DateOfContract);
                command.Parameters.AddWithValue("@StartDate", contract.StartDate);
                command.Parameters.AddWithValue("@EndDate", contract.EndDate);
                command.Parameters.AddWithValue("@OriginalAmount", contract.OriginalAmount);
                command.Parameters.AddWithValue("@RevisedAmount", contract.RevisedAmount);
                command.Parameters.AddWithValue("@AmcType", contract.AmcType);
                command.Parameters.AddWithValue("@BudgetType", contract.BudgetType);
                command.Parameters.AddWithValue("@PaymentType", contract.PaymentType);
                command.Parameters.AddWithValue("@ServiceType", contract.ServiceType);

                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
                connection.Close();
            }

            return rowsAffected > 0;
        }


        //Delete Product

        public string DeleteContract(int ContractNumber)
        {
            string result = "";

            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "DELETE FROM dbo.details WHERE ContractNumber = @ContractNumber";
                command.Parameters.AddWithValue("@ContractNumber", ContractNumber);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                connection.Close();

                if (rowsAffected > 0)
                {
                    result = "Contract deleted successfully...!";
                }
                else
                {
                    result = "Contract not found.";
                }
            }

            return result;
        }

    }
}