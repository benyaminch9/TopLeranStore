using System;
using System.Collections.Generic;
using System.Text;
using TopLearn.Core.DTOs;
using TopLearn.DataLayer.Entities.User;
using TopLearn.DataLayer.Entities.Wallet;

namespace TopLearn.Core.Services.Interfaces
{
    public interface IUserServices
    {
        bool IsExistUserName(string userName);
        bool IsExistEmail(string email);
        int AddUser(User user);
        User LoginUser(LoginViewModel login);
        User GetUserByEmail(string email);
        User GetUserByActiveCode(string activeCode);
        User GetUserByUserName(string username);
        void UpdateUser(User user);
        bool ActiveAccount(string activeCode);

        #region User Panel

        InfomationUserViewModel GetUserInformation(string userName);
        SideBarUserPanelViewModel GetSideBarUserPanelData(string userName);
        EditProfileViewModel GetDataForEditProfileUser(string username);
        void EditProfile(string username, EditProfileViewModel profile);
        bool CompareOldPassword(string oldPassword, string username);
        void ChangeUserPassword(string userName, string newPassword);

        #endregion

        #region Wallet

        int BalancUserWallet(string userName);
        int GetUserIdByUserName(string userName);
        List<WalletViewModel> GetWalletUser(string userName);
        int ChageWallet(string userName, int amount, string Description, bool isPay=false);
        int AddWallet(Wallet wallet);
        Wallet GetWalletByWalletId(int walletId);
        void UpdateWallet(Wallet wallet);

        #endregion
    }
}
