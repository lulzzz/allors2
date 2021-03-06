namespace Allors.Repository
{
    using System;

    using Attributes;

    #region Allors
    [Id("441f6007-022d-4d77-bc2d-04c7a876e1bd")]
    #endregion
    public partial class ItemIssuance : Deletable, AccessControlledObject 
    {
        #region inherited properties
        public Permission[] DeniedPermissions { get; set; }

        public SecurityToken[] SecurityTokens { get; set; }

        #endregion

        #region Allors
        [Id("60089b34-e9aa-4b09-9a5c-4523ce60152f")]
        [AssociationId("ddf8eba9-8821-490f-9d9d-adc6ebd32ddb")]
        [RoleId("ee8e4f06-63e8-4281-a010-9f9212244cf1")]
        #endregion
        public DateTime IssuanceDateTime { get; set; }
        
        #region Allors
        [Id("6d0e1669-1583-4004-a0dd-6481faaa4803")]
        [AssociationId("2deb9c3e-6e3e-462c-88bf-df682a4af6e0")]
        [RoleId("d8e7874c-a162-440a-8e99-4dd7b07216cd")]
        #endregion
        [Multiplicity(Multiplicity.ManyToOne)]
        [Indexed]
        [Required]
        public InventoryItem InventoryItem { get; set; }
        
        #region Allors
        [Id("72872b29-69e3-4408-ad61-80201c46421b")]
        [AssociationId("f191b03b-fb03-4c5b-9455-57d241160e3b")]
        [RoleId("69dca6e4-7d13-481c-8a77-ff4c365df923")]
        #endregion
        [Required]
        [Precision(19)]
        [Scale(2)]
        public decimal Quantity { get; set; }
        
        #region Allors
        [Id("83de0bfa-98ca-4299-a529-f8ba8a02cb90")]
        [AssociationId("467ce53a-969b-4537-b51c-998ac64afbe9")]
        [RoleId("1766b9c8-436d-427c-8c54-4f10a6accf02")]
        #endregion
        [Multiplicity(Multiplicity.ManyToOne)]
        [Indexed]
        [Required]
        public ShipmentItem ShipmentItem { get; set; }
        
        #region Allors
        [Id("af4fbe17-bbdc-4f05-bf2e-398ee18598a5")]
        [AssociationId("6744410c-6f9c-49db-b73c-ed723592fee6")]
        [RoleId("938bb734-f18c-4756-9c68-54cad2377639")]
        #endregion
        [Multiplicity(Multiplicity.ManyToOne)]
        [Indexed]
        public PickListItem PickListItem { get; set; }
        
        #region inherited methods


        public void OnBuild(){}

        public void OnPostBuild(){}

        public void OnPreDerive(){}

        public void OnDerive(){}

        public void OnPostDerive(){}


        public void Delete(){}

        #endregion
    }
}