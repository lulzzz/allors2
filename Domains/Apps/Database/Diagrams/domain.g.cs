namespace Allors.Domain
{
		public interface Deletable  : Object 
		{
		}
		public interface Enumeration  : AccessControlledObject, UniquelyIdentifiable 
		{
						LocalisedText LocalisedNames {set;}

						global::System.String Name {set;}

						global::System.Boolean IsActive {set;}

		}
		public interface Object 
		{
		}
		public interface UniquelyIdentifiable  : Object 
		{
						global::System.Guid UniqueId {set;}

		}
		public interface Version  : AccessControlledObject 
		{
						global::System.Guid? DerivationId {set;}

						global::System.DateTime? DerivationTimeStamp {set;}

		}
		public interface Versioned  : Object 
		{
		}
		public interface Localised  : Object 
		{
						Locale Locale {set;}

		}
		public interface AccessControlledObject  : Object 
		{
						Permission DeniedPermissions {set;}

						SecurityToken SecurityTokens {set;}

		}
		public interface SecurityTokenOwner  : Object 
		{
						SecurityToken OwnerSecurityToken {set;}

						AccessControl OwnerAccessControl {set;}

		}
		public interface ObjectState  : UniquelyIdentifiable 
		{
						Permission DeniedPermissions {set;}

						global::System.String Name {set;}

		}
		public interface Task  : AccessControlledObject, UniquelyIdentifiable, Deletable 
		{
						WorkItem WorkItem {set;}

						global::System.DateTime DateCreated {set;}

						global::System.DateTime? DateClosed {set;}

						Person Participants {set;}

						Person Performer {set;}

		}
		public interface Transitional  : AccessControlledObject 
		{
						ObjectState PreviousObjectState {set;}

						ObjectState LastObjectState {set;}

		}
		public interface User  : SecurityTokenOwner, AccessControlledObject, Localised 
		{
						global::System.String UserName {set;}

						global::System.String NormalizedUserName {set;}

						global::System.String UserPasswordHash {set;}

						global::System.String UserEmail {set;}

						global::System.Boolean? UserEmailConfirmed {set;}

						TaskList TaskList {set;}

						NotificationList NotificationList {set;}

		}
		public interface WorkItem  : Object 
		{
						global::System.String WorkItemDescription {set;}

		}
		public interface AccountingTransaction  : AccessControlledObject 
		{
						AccountingTransactionDetail AccountingTransactionDetails {set;}

						global::System.String Description {set;}

						global::System.DateTime TransactionDate {set;}

						global::System.Decimal DerivedTotalAmount {set;}

						AccountingTransactionNumber AccountingTransactionNumber {set;}

						global::System.DateTime EntryDate {set;}

		}
		public interface Agreement  : AccessControlledObject, UniquelyIdentifiable, Period 
		{
						global::System.DateTime? AgreementDate {set;}

						Addendum Addenda {set;}

						global::System.String Description {set;}

						AgreementTerm AgreementTerms {set;}

						global::System.String Text {set;}

						AgreementItem AgreementItems {set;}

						global::System.String AgreementNumber {set;}

		}
		public interface AgreementItem  : AccessControlledObject 
		{
						global::System.String Text {set;}

						Addendum Addenda {set;}

						AgreementItem Children {set;}

						global::System.String Description {set;}

						AgreementTerm AgreementTerms {set;}

		}
		public interface AgreementTerm  : AccessControlledObject 
		{
						global::System.String TermValue {set;}

						TermType TermType {set;}

						global::System.String Description {set;}

		}
		public interface Auditable  : AccessControlledObject 
		{
						User CreatedBy {set;}

						User LastModifiedBy {set;}

						global::System.DateTime? CreationDate {set;}

						global::System.DateTime? LastModifiedDate {set;}

		}
		public interface Budget  : Period, Commentable, UniquelyIdentifiable, Transitional 
		{
						global::System.String Description {set;}

						BudgetRevision BudgetRevisions {set;}

						BudgetStatus BudgetStatuses {set;}

						global::System.String BudgetNumber {set;}

						BudgetObjectState CurrentObjectState {set;}

						BudgetReview BudgetReviews {set;}

						BudgetStatus CurrentBudgetStatus {set;}

						BudgetItem BudgetItems {set;}

		}
		public interface CityBound  : AccessControlledObject 
		{
						City Cities {set;}

		}
		public interface Commentable  : Object 
		{
						global::System.String Comment {set;}

		}
		public interface CommunicationAttachment  : AccessControlledObject 
		{
		}
		public interface CommunicationEventVersion  : Version 
		{
						SecurityToken OwnerSecurityToken {set;}

						AccessControl OwnerAccessControl {set;}

						global::System.DateTime? ScheduledStart {set;}

						Party ToParties {set;}

						ContactMechanism ContactMechanisms {set;}

						Party InvolvedParties {set;}

						global::System.DateTime? InitialScheduledStart {set;}

						CommunicationEventObjectState CurrentObjectState {set;}

						CommunicationEventPurpose EventPurposes {set;}

						global::System.DateTime? ScheduledEnd {set;}

						global::System.DateTime? ActualEnd {set;}

						WorkEffort WorkEfforts {set;}

						global::System.String Description {set;}

						global::System.DateTime? InitialScheduledEnd {set;}

						Party FromParties {set;}

						global::System.String Subject {set;}

						Media Documents {set;}

						Case Case {set;}

						Priority Priority {set;}

						Person Owner {set;}

						global::System.String Note {set;}

						global::System.DateTime? ActualStart {set;}

						global::System.Boolean? SendNotification {set;}

						global::System.Boolean? SendReminder {set;}

						global::System.DateTime? RemindAt {set;}

		}
		public interface CommunicationEvent  : Deletable, Commentable, UniquelyIdentifiable, Auditable, Transitional 
		{
						SecurityToken OwnerSecurityToken {set;}

						AccessControl OwnerAccessControl {set;}

						global::System.DateTime? ScheduledStart {set;}

						Party ToParties {set;}

						ContactMechanism ContactMechanisms {set;}

						Party InvolvedParties {set;}

						global::System.DateTime? InitialScheduledStart {set;}

						CommunicationEventObjectState CurrentObjectState {set;}

						CommunicationEventPurpose EventPurposes {set;}

						global::System.DateTime? ScheduledEnd {set;}

						global::System.DateTime? ActualEnd {set;}

						WorkEffort WorkEfforts {set;}

						global::System.String Description {set;}

						global::System.DateTime? InitialScheduledEnd {set;}

						Party FromParties {set;}

						global::System.String Subject {set;}

						Media Documents {set;}

						Case Case {set;}

						Priority Priority {set;}

						Person Owner {set;}

						global::System.String Note {set;}

						global::System.DateTime? ActualStart {set;}

						global::System.Boolean? SendNotification {set;}

						global::System.Boolean? SendReminder {set;}

						global::System.DateTime? RemindAt {set;}

		}
		public interface ContactMechanism  : Auditable, Deletable 
		{
						global::System.String Description {set;}

						ContactMechanism FollowTo {set;}

						ContactMechanismType ContactMechanismType {set;}

		}
		public interface Container  : AccessControlledObject 
		{
						Facility Facility {set;}

						global::System.String ContainerDescription {set;}

		}
		public interface CountryBound  : AccessControlledObject 
		{
						Country Country {set;}

		}
		public interface DeploymentUsage  : AccessControlledObject, Commentable, Period 
		{
						TimeFrequency TimeFrequency {set;}

		}
		public interface Document  : Printable, Commentable 
		{
						global::System.String Name {set;}

						global::System.String Description {set;}

						global::System.String Text {set;}

						global::System.String DocumentLocation {set;}

		}
		public interface ElectronicAddress  : ContactMechanism 
		{
						global::System.String ElectronicAddressString {set;}

		}
		public interface EngagementItem  : AccessControlledObject 
		{
						QuoteItem QuoteItem {set;}

						global::System.String Description {set;}

						global::System.DateTime? ExpectedStartDate {set;}

						global::System.DateTime? ExpectedEndDate {set;}

						WorkEffort EngagementWorkFulfillment {set;}

						EngagementRate EngagementRates {set;}

						EngagementRate CurrentEngagementRate {set;}

						EngagementItem OrderedWiths {set;}

						Person CurrentAssignedProfessional {set;}

						Product Product {set;}

						ProductFeature ProductFeature {set;}

		}
		public interface EstimatedProductCost  : Period, AccessControlledObject 
		{
						global::System.Decimal Cost {set;}

						Currency Currency {set;}

						Organisation Organisation {set;}

						global::System.String Description {set;}

						GeographicBoundary GeographicBoundary {set;}

		}
		public interface ExternalAccountingTransaction  : AccountingTransaction 
		{
						Party FromParty {set;}

						Party ToParty {set;}

		}
		public interface Facility  : GeoLocatable 
		{
						Facility MadeUpOf {set;}

						global::System.Decimal? SquareFootage {set;}

						global::System.String Description {set;}

						ContactMechanism FacilityContactMechanisms {set;}

						global::System.String Name {set;}

		}
		public interface FinancialAccount  : AccessControlledObject 
		{
						FinancialAccountTransaction FinancialAccountTransactions {set;}

		}
		public interface FinancialAccountTransaction  : AccessControlledObject 
		{
						global::System.String Description {set;}

						global::System.DateTime? EntryDate {set;}

						global::System.DateTime TransactionDate {set;}

		}
		public interface FixedAsset  : AccessControlledObject 
		{
						global::System.String Name {set;}

						global::System.DateTime? LastServiceDate {set;}

						global::System.DateTime? AcquiredDate {set;}

						global::System.String Description {set;}

						global::System.Decimal? ProductionCapacity {set;}

						global::System.DateTime? NextServiceDate {set;}

		}
		public interface GeographicBoundary  : GeoLocatable 
		{
						global::System.String Abbreviation {set;}

		}
		public interface GeographicBoundaryComposite  : GeographicBoundary 
		{
						GeographicBoundary Associations {set;}

		}
		public interface GeoLocatable  : AccessControlledObject, UniquelyIdentifiable 
		{
						global::System.Decimal Latitude {set;}

						global::System.Decimal Longitude {set;}

		}
		public interface InternalAccountingTransaction  : AccountingTransaction 
		{
						InternalOrganisation InternalOrganisation {set;}

		}
		public interface InventoryItemVersion  : Version 
		{
						ProductCharacteristicValue ProductCharacteristicValues {set;}

						InventoryItemVariance InventoryItemVariances {set;}

						Part Part {set;}

						Container Container {set;}

						global::System.String Name {set;}

						Lot Lot {set;}

						global::System.String Sku {set;}

						UnitOfMeasure UnitOfMeasure {set;}

						ProductCategory DerivedProductCategories {set;}

						Good Good {set;}

						ProductType ProductType {set;}

						Facility Facility {set;}

		}
		public interface InventoryItem  : UniquelyIdentifiable, Transitional 
		{
						ProductCharacteristicValue ProductCharacteristicValues {set;}

						InventoryItemVariance InventoryItemVariances {set;}

						Part Part {set;}

						Container Container {set;}

						global::System.String Name {set;}

						Lot Lot {set;}

						global::System.String Sku {set;}

						UnitOfMeasure UnitOfMeasure {set;}

						ProductCategory DerivedProductCategories {set;}

						Good Good {set;}

						ProductType ProductType {set;}

						Facility Facility {set;}

		}
		public interface InventoryItemConfiguration  : Commentable, AccessControlledObject 
		{
						InventoryItem InventoryItem {set;}

						global::System.Int32 Quantity {set;}

						InventoryItem ComponentInventoryItem {set;}

		}
		public interface InvoiceItemVersion  : PriceableVersion 
		{
						global::System.String InternalComment {set;}

						AgreementTerm InvoiceTerms {set;}

						global::System.Decimal TotalInvoiceAdjustment {set;}

						InvoiceVatRateItem InvoiceVatRateItems {set;}

						InvoiceItem AdjustmentFor {set;}

						SerialisedInventoryItem SerializedInventoryItem {set;}

						global::System.String Message {set;}

						global::System.Decimal TotalInvoiceAdjustmentCustomerCurrency {set;}

						global::System.Decimal AmountPaid {set;}

						global::System.Decimal Quantity {set;}

						global::System.String Description {set;}

		}
		public interface InvoiceVersion  : Version 
		{
						global::System.String InternalComment {set;}

						global::System.Decimal TotalShippingAndHandlingCustomerCurrency {set;}

						Currency CustomerCurrency {set;}

						global::System.String Description {set;}

						ShippingAndHandlingCharge ShippingAndHandlingCharge {set;}

						global::System.Decimal TotalFeeCustomerCurrency {set;}

						Fee Fee {set;}

						global::System.Decimal TotalExVatCustomerCurrency {set;}

						global::System.String CustomerReference {set;}

						DiscountAdjustment DiscountAdjustment {set;}

						global::System.Decimal AmountPaid {set;}

						global::System.Decimal TotalDiscount {set;}

						BillingAccount BillingAccount {set;}

						global::System.Decimal TotalIncVat {set;}

						global::System.Decimal TotalSurcharge {set;}

						global::System.Decimal TotalBasePrice {set;}

						global::System.Decimal TotalVatCustomerCurrency {set;}

						global::System.DateTime InvoiceDate {set;}

						global::System.DateTime EntryDate {set;}

						global::System.Decimal TotalIncVatCustomerCurrency {set;}

						global::System.Decimal TotalShippingAndHandling {set;}

						global::System.Decimal TotalBasePriceCustomerCurrency {set;}

						SurchargeAdjustment SurchargeAdjustment {set;}

						global::System.Decimal TotalExVat {set;}

						InvoiceTerm InvoiceTerms {set;}

						global::System.Decimal TotalSurchargeCustomerCurrency {set;}

						global::System.String InvoiceNumber {set;}

						global::System.String Message {set;}

						VatRegime VatRegime {set;}

						global::System.Decimal TotalDiscountCustomerCurrency {set;}

						global::System.Decimal TotalVat {set;}

						global::System.Decimal TotalFee {set;}

		}
		public interface Invoice  : Localised, Commentable, Printable, Auditable, Transitional 
		{
						global::System.String InternalComment {set;}

						global::System.Decimal TotalShippingAndHandlingCustomerCurrency {set;}

						Currency CustomerCurrency {set;}

						global::System.String Description {set;}

						ShippingAndHandlingCharge ShippingAndHandlingCharge {set;}

						global::System.Decimal TotalFeeCustomerCurrency {set;}

						Fee Fee {set;}

						global::System.Decimal TotalExVatCustomerCurrency {set;}

						global::System.String CustomerReference {set;}

						DiscountAdjustment DiscountAdjustment {set;}

						global::System.Decimal AmountPaid {set;}

						global::System.Decimal TotalDiscount {set;}

						BillingAccount BillingAccount {set;}

						global::System.Decimal TotalIncVat {set;}

						global::System.Decimal TotalSurcharge {set;}

						global::System.Decimal TotalBasePrice {set;}

						global::System.Decimal TotalVatCustomerCurrency {set;}

						global::System.DateTime InvoiceDate {set;}

						global::System.DateTime EntryDate {set;}

						global::System.Decimal TotalIncVatCustomerCurrency {set;}

						global::System.Decimal TotalShippingAndHandling {set;}

						global::System.Decimal TotalBasePriceCustomerCurrency {set;}

						SurchargeAdjustment SurchargeAdjustment {set;}

						global::System.Decimal TotalExVat {set;}

						InvoiceTerm InvoiceTerms {set;}

						global::System.Decimal TotalSurchargeCustomerCurrency {set;}

						global::System.String InvoiceNumber {set;}

						global::System.String Message {set;}

						VatRegime VatRegime {set;}

						global::System.Decimal TotalDiscountCustomerCurrency {set;}

						global::System.Decimal TotalVat {set;}

						global::System.Decimal TotalFee {set;}

		}
		public interface InvoiceItem  : Priceable 
		{
						global::System.String InternalComment {set;}

						AgreementTerm InvoiceTerms {set;}

						global::System.Decimal TotalInvoiceAdjustment {set;}

						InvoiceVatRateItem InvoiceVatRateItems {set;}

						InvoiceItem AdjustmentFor {set;}

						SerialisedInventoryItem SerializedInventoryItem {set;}

						global::System.String Message {set;}

						global::System.Decimal TotalInvoiceAdjustmentCustomerCurrency {set;}

						global::System.Decimal AmountPaid {set;}

						global::System.Decimal Quantity {set;}

						global::System.String Description {set;}

		}
		public interface IUnitOfMeasure  : AccessControlledObject, UniquelyIdentifiable 
		{
						global::System.String Description {set;}

						UnitOfMeasureConversion UnitOfMeasureConversions {set;}

						global::System.String Abbreviation {set;}

		}
		public interface OrderAdjustmentVersion  : Version 
		{
						global::System.Decimal? Amount {set;}

						VatRate VatRate {set;}

						global::System.Decimal? Percentage {set;}

		}
		public interface OrderItemVersion  : PriceableVersion 
		{
						global::System.String InternalComment {set;}

						BudgetItem BudgetItem {set;}

						global::System.Decimal PreviousQuantity {set;}

						global::System.Decimal QuantityOrdered {set;}

						global::System.String Description {set;}

						PurchaseOrder CorrespondingPurchaseOrder {set;}

						global::System.Decimal TotalOrderAdjustmentCustomerCurrency {set;}

						global::System.Decimal TotalOrderAdjustment {set;}

						QuoteItem QuoteItem {set;}

						global::System.DateTime? AssignedDeliveryDate {set;}

						global::System.DateTime? DeliveryDate {set;}

						OrderTerm OrderTerms {set;}

						global::System.String ShippingInstruction {set;}

						OrderItem Associations {set;}

						global::System.String Message {set;}

		}
		public interface OrderVersion  : Version 
		{
						global::System.String InternalComment {set;}

						Currency CustomerCurrency {set;}

						global::System.Decimal TotalBasePriceCustomerCurrency {set;}

						global::System.Decimal TotalIncVatCustomerCurrency {set;}

						global::System.Decimal TotalDiscountCustomerCurrency {set;}

						global::System.String CustomerReference {set;}

						Fee Fee {set;}

						global::System.Decimal TotalExVat {set;}

						OrderTerm OrderTerms {set;}

						global::System.Decimal TotalVat {set;}

						global::System.Decimal TotalSurcharge {set;}

						OrderItem ValidOrderItems {set;}

						global::System.String OrderNumber {set;}

						global::System.Decimal TotalVatCustomerCurrency {set;}

						global::System.Decimal TotalDiscount {set;}

						global::System.String Message {set;}

						global::System.Decimal TotalShippingAndHandlingCustomerCurrency {set;}

						global::System.DateTime EntryDate {set;}

						DiscountAdjustment DiscountAdjustment {set;}

						OrderKind OrderKind {set;}

						global::System.Decimal TotalIncVat {set;}

						global::System.Decimal TotalSurchargeCustomerCurrency {set;}

						VatRegime VatRegime {set;}

						global::System.Decimal TotalFeeCustomerCurrency {set;}

						global::System.Decimal TotalShippingAndHandling {set;}

						ShippingAndHandlingCharge ShippingAndHandlingCharge {set;}

						global::System.DateTime OrderDate {set;}

						global::System.Decimal TotalExVatCustomerCurrency {set;}

						global::System.DateTime? DeliveryDate {set;}

						global::System.Decimal TotalBasePrice {set;}

						global::System.Decimal TotalFee {set;}

						SurchargeAdjustment SurchargeAdjustment {set;}

		}
		public interface PartyRelationship  : Period, AccessControlledObject, Deletable 
		{
						Party Parties {set;}

		}
		public interface PriceableVersion  : Version 
		{
						global::System.Decimal? TotalDiscountAsPercentage {set;}

						DiscountAdjustment DiscountAdjustment {set;}

						global::System.Decimal UnitVat {set;}

						global::System.Decimal TotalVatCustomerCurrency {set;}

						VatRegime VatRegime {set;}

						global::System.Decimal TotalVat {set;}

						global::System.Decimal UnitSurcharge {set;}

						global::System.Decimal UnitDiscount {set;}

						global::System.Decimal TotalExVatCustomerCurrency {set;}

						VatRate DerivedVatRate {set;}

						global::System.Decimal? ActualUnitPrice {set;}

						global::System.Decimal TotalIncVatCustomerCurrency {set;}

						global::System.Decimal UnitBasePrice {set;}

						global::System.Decimal CalculatedUnitPrice {set;}

						global::System.Decimal TotalSurchargeCustomerCurrency {set;}

						global::System.Decimal TotalIncVat {set;}

						global::System.Decimal? TotalSurchargeAsPercentage {set;}

						global::System.Decimal TotalDiscountCustomerCurrency {set;}

						global::System.Decimal TotalDiscount {set;}

						global::System.Decimal TotalSurcharge {set;}

						VatRegime AssignedVatRegime {set;}

						global::System.Decimal TotalBasePrice {set;}

						global::System.Decimal TotalExVat {set;}

						global::System.Decimal TotalBasePriceCustomerCurrency {set;}

						PriceComponent CurrentPriceComponents {set;}

						SurchargeAdjustment SurchargeAdjustment {set;}

		}
		public interface QuoteVersion  : Version 
		{
						global::System.String InternalComment {set;}

						global::System.DateTime? RequiredResponseDate {set;}

						global::System.DateTime? ValidFromDate {set;}

						QuoteTerm QuoteTerms {set;}

						Party Issuer {set;}

						global::System.DateTime? ValidThroughDate {set;}

						global::System.String Description {set;}

						Party Receiver {set;}

						ContactMechanism FullfillContactMechanism {set;}

						global::System.Decimal? Amount {set;}

						Currency Currency {set;}

						global::System.DateTime? IssueDate {set;}

						QuoteItem QuoteItems {set;}

						global::System.String QuoteNumber {set;}

						QuoteObjectState CurrentObjectState {set;}

						Request Request {set;}

		}
		public interface RequestVersion  : Version 
		{
						RequestObjectState CurrentObjectState {set;}

						global::System.String InternalComment {set;}

						global::System.String Description {set;}

						global::System.DateTime RequestDate {set;}

						global::System.DateTime? RequiredResponseDate {set;}

						RequestItem RequestItems {set;}

						global::System.String RequestNumber {set;}

						RespondingParty RespondingParties {set;}

						Party Originator {set;}

						Currency Currency {set;}

						ContactMechanism FullfillContactMechanism {set;}

						global::System.String EmailAddress {set;}

						global::System.String TelephoneNumber {set;}

						global::System.String TelephoneCountryCode {set;}

		}
		public interface Order  : Printable, Commentable, Localised, Auditable, Transitional 
		{
						global::System.String InternalComment {set;}

						Currency CustomerCurrency {set;}

						global::System.Decimal TotalBasePriceCustomerCurrency {set;}

						global::System.Decimal TotalIncVatCustomerCurrency {set;}

						global::System.Decimal TotalDiscountCustomerCurrency {set;}

						global::System.String CustomerReference {set;}

						Fee Fee {set;}

						global::System.Decimal TotalExVat {set;}

						OrderTerm OrderTerms {set;}

						global::System.Decimal TotalVat {set;}

						global::System.Decimal TotalSurcharge {set;}

						OrderItem ValidOrderItems {set;}

						global::System.String OrderNumber {set;}

						global::System.Decimal TotalVatCustomerCurrency {set;}

						global::System.Decimal TotalDiscount {set;}

						global::System.String Message {set;}

						global::System.Decimal TotalShippingAndHandlingCustomerCurrency {set;}

						global::System.DateTime EntryDate {set;}

						DiscountAdjustment DiscountAdjustment {set;}

						OrderKind OrderKind {set;}

						global::System.Decimal TotalIncVat {set;}

						global::System.Decimal TotalSurchargeCustomerCurrency {set;}

						VatRegime VatRegime {set;}

						global::System.Decimal TotalFeeCustomerCurrency {set;}

						global::System.Decimal TotalShippingAndHandling {set;}

						ShippingAndHandlingCharge ShippingAndHandlingCharge {set;}

						global::System.DateTime OrderDate {set;}

						global::System.Decimal TotalExVatCustomerCurrency {set;}

						global::System.DateTime? DeliveryDate {set;}

						global::System.Decimal TotalBasePrice {set;}

						global::System.Decimal TotalFee {set;}

						SurchargeAdjustment SurchargeAdjustment {set;}

		}
		public interface OrderAdjustment  : AccessControlledObject 
		{
						global::System.Decimal? Amount {set;}

						VatRate VatRate {set;}

						global::System.Decimal? Percentage {set;}

		}
		public interface OrderItem  : Priceable 
		{
						global::System.String InternalComment {set;}

						BudgetItem BudgetItem {set;}

						global::System.Decimal PreviousQuantity {set;}

						global::System.Decimal QuantityOrdered {set;}

						global::System.String Description {set;}

						PurchaseOrder CorrespondingPurchaseOrder {set;}

						global::System.Decimal TotalOrderAdjustmentCustomerCurrency {set;}

						global::System.Decimal TotalOrderAdjustment {set;}

						QuoteItem QuoteItem {set;}

						global::System.DateTime? AssignedDeliveryDate {set;}

						global::System.DateTime? DeliveryDate {set;}

						OrderTerm OrderTerms {set;}

						global::System.String ShippingInstruction {set;}

						OrderItem Associations {set;}

						global::System.String Message {set;}

		}
		public interface OrganisationClassification  : PartyClassification 
		{
		}
		public interface Part  : AccessControlledObject, UniquelyIdentifiable 
		{
						global::System.String Name {set;}

						PartSpecification PartSpecifications {set;}

						UnitOfMeasure UnitOfMeasure {set;}

						Document Documents {set;}

						global::System.String ManufacturerId {set;}

						global::System.Int32? ReorderLevel {set;}

						global::System.Int32? ReorderQuantity {set;}

						PriceComponent PriceComponents {set;}

						InventoryItemKind InventoryItemKind {set;}

						global::System.String Sku {set;}

		}
		public interface PartBillOfMaterial  : AccessControlledObject, Commentable, Period 
		{
						Part Part {set;}

						global::System.String Instruction {set;}

						global::System.Int32 QuantityUsed {set;}

						Part ComponentPart {set;}

		}
		public interface PartSpecification  : UniquelyIdentifiable, Commentable, Transitional 
		{
						PartSpecificationStatus PartSpecificationStatuses {set;}

						PartSpecificationObjectState CurrentObjectState {set;}

						global::System.DateTime? DocumentationDate {set;}

						PartSpecificationStatus CurrentPartSpecificationStatus {set;}

						global::System.String Description {set;}

		}
		public interface Party  : Localised, Auditable, UniquelyIdentifiable, Commentable 
		{
						PostalAddress GeneralCorrespondence {set;}

						global::System.Decimal YTDRevenue {set;}

						global::System.Decimal LastYearsRevenue {set;}

						TelecommunicationsNumber BillingInquiriesFax {set;}

						Qualification Qualifications {set;}

						ContactMechanism HomeAddress {set;}

						OrganisationContactRelationship InactiveOrganisationContactRelationships {set;}

						ContactMechanism SalesOffice {set;}

						Person InactiveContacts {set;}

						PartyContactMechanism InactivePartyContactMechanisms {set;}

						TelecommunicationsNumber OrderInquiriesFax {set;}

						Person CurrentSalesReps {set;}

						PartyContactMechanism PartyContactMechanisms {set;}

						TelecommunicationsNumber ShippingInquiriesFax {set;}

						TelecommunicationsNumber ShippingInquiriesPhone {set;}

						BillingAccount BillingAccounts {set;}

						TelecommunicationsNumber OrderInquiriesPhone {set;}

						PartySkill PartySkills {set;}

						PartyClassification PartyClassifications {set;}

						global::System.Boolean? ExcludeFromDunning {set;}

						BankAccount BankAccounts {set;}

						Person CurrentContacts {set;}

						ContactMechanism BillingAddress {set;}

						ElectronicAddress GeneralEmail {set;}

						ShipmentMethod DefaultShipmentMethod {set;}

						Resume Resumes {set;}

						ContactMechanism HeadQuarter {set;}

						ElectronicAddress PersonalEmailAddress {set;}

						TelecommunicationsNumber CellPhoneNumber {set;}

						TelecommunicationsNumber BillingInquiriesPhone {set;}

						ContactMechanism OrderAddress {set;}

						ElectronicAddress InternetAddress {set;}

						Media Contents {set;}

						CreditCard CreditCards {set;}

						PostalAddress ShippingAddress {set;}

						OrganisationContactRelationship CurrentOrganisationContactRelationships {set;}

						global::System.Decimal OpenOrderAmount {set;}

						TelecommunicationsNumber GeneralFaxNumber {set;}

						PaymentMethod DefaultPaymentMethod {set;}

						PartyContactMechanism CurrentPartyContactMechanisms {set;}

						TelecommunicationsNumber GeneralPhoneNumber {set;}

						Currency PreferredCurrency {set;}

						VatRegime VatRegime {set;}

						global::System.Decimal? SimpleMovingAverage {set;}

						global::System.Decimal AmountOverDue {set;}

						DunningType DunningType {set;}

						global::System.Decimal AmountDue {set;}

						global::System.DateTime? LastReminderDate {set;}

						global::System.Decimal? CreditLimit {set;}

						global::System.Int32 SubAccountNumber {set;}

						global::System.DateTime? BlockedForDunning {set;}

						Agreement Agreements {set;}

						CommunicationEvent CommunicationEvents {set;}

		}
		public interface PartyClassification  : AccessControlledObject 
		{
						global::System.String Name {set;}

		}
		public interface Payment  : AccessControlledObject, Commentable, UniquelyIdentifiable 
		{
						global::System.Decimal Amount {set;}

						PaymentMethod PaymentMethod {set;}

						global::System.DateTime EffectiveDate {set;}

						Party SendingParty {set;}

						PaymentApplication PaymentApplications {set;}

						global::System.String ReferenceNumber {set;}

						Party ReceivingParty {set;}

		}
		public interface PaymentMethod  : AccessControlledObject, UniquelyIdentifiable 
		{
						global::System.Decimal? BalanceLimit {set;}

						global::System.Decimal CurrentBalance {set;}

						Journal Journal {set;}

						global::System.String Description {set;}

						OrganisationGlAccount GlPaymentInTransit {set;}

						global::System.String Remarks {set;}

						OrganisationGlAccount GeneralLedgerAccount {set;}

						Party Creditor {set;}

						global::System.Boolean IsActive {set;}

		}
		public interface Period  : Object 
		{
						global::System.DateTime FromDate {set;}

						global::System.DateTime? ThroughDate {set;}

		}
		public interface PersonClassification  : PartyClassification 
		{
		}
		public interface Priceable  : Commentable, Transitional 
		{
						global::System.Decimal? TotalDiscountAsPercentage {set;}

						DiscountAdjustment DiscountAdjustment {set;}

						global::System.Decimal UnitVat {set;}

						global::System.Decimal TotalVatCustomerCurrency {set;}

						VatRegime VatRegime {set;}

						global::System.Decimal TotalVat {set;}

						global::System.Decimal UnitSurcharge {set;}

						global::System.Decimal UnitDiscount {set;}

						global::System.Decimal TotalExVatCustomerCurrency {set;}

						VatRate DerivedVatRate {set;}

						global::System.Decimal? ActualUnitPrice {set;}

						global::System.Decimal TotalIncVatCustomerCurrency {set;}

						global::System.Decimal UnitBasePrice {set;}

						global::System.Decimal CalculatedUnitPrice {set;}

						global::System.Decimal TotalSurchargeCustomerCurrency {set;}

						global::System.Decimal TotalIncVat {set;}

						global::System.Decimal? TotalSurchargeAsPercentage {set;}

						global::System.Decimal TotalDiscountCustomerCurrency {set;}

						global::System.Decimal TotalDiscount {set;}

						global::System.Decimal TotalSurcharge {set;}

						VatRegime AssignedVatRegime {set;}

						global::System.Decimal TotalBasePrice {set;}

						global::System.Decimal TotalExVat {set;}

						global::System.Decimal TotalBasePriceCustomerCurrency {set;}

						PriceComponent CurrentPriceComponents {set;}

						SurchargeAdjustment SurchargeAdjustment {set;}

		}
		public interface PriceComponent  : Period, AccessControlledObject, Commentable 
		{
						GeographicBoundary GeographicBoundary {set;}

						global::System.Decimal? Rate {set;}

						RevenueValueBreak RevenueValueBreak {set;}

						PartyClassification PartyClassification {set;}

						OrderQuantityBreak OrderQuantityBreak {set;}

						PackageQuantityBreak PackageQuantityBreak {set;}

						Product Product {set;}

						RevenueQuantityBreak RevenueQuantityBreak {set;}

						Party SpecifiedFor {set;}

						ProductFeature ProductFeature {set;}

						AgreementPricingProgram AgreementPricingProgram {set;}

						global::System.String Description {set;}

						Currency Currency {set;}

						OrderKind OrderKind {set;}

						OrderValue OrderValue {set;}

						global::System.Decimal? Price {set;}

						ProductCategory ProductCategory {set;}

						SalesChannel SalesChannel {set;}

		}
		public interface Printable  : AccessControlledObject, UniquelyIdentifiable 
		{
						global::System.String PrintContent {set;}

		}
		public interface Product  : Commentable, UniquelyIdentifiable, AccessControlledObject 
		{
						global::System.String InternalComment {set;}

						ProductCategory PrimaryProductCategory {set;}

						global::System.DateTime? SupportDiscontinuationDate {set;}

						global::System.DateTime? SalesDiscontinuationDate {set;}

						LocalisedText LocalisedNames {set;}

						LocalisedText LocalisedDescriptions {set;}

						LocalisedText LocalisedComments {set;}

						global::System.String Description {set;}

						PriceComponent VirtualProductPriceComponents {set;}

						global::System.String IntrastatCode {set;}

						ProductCategory ProductCategoriesExpanded {set;}

						Product ProductComplement {set;}

						ProductFeature OptionalFeatures {set;}

						Product Variants {set;}

						global::System.String Name {set;}

						global::System.DateTime? IntroductionDate {set;}

						Document Documents {set;}

						ProductFeature StandardFeatures {set;}

						UnitOfMeasure UnitOfMeasure {set;}

						EstimatedProductCost EstimatedProductCosts {set;}

						Product ProductObsolescences {set;}

						ProductFeature SelectableFeatures {set;}

						VatRate VatRate {set;}

						PriceComponent BasePrices {set;}

						ProductCategory ProductCategories {set;}

		}
		public interface ProductAssociation  : Commentable, AccessControlledObject, Period 
		{
		}
		public interface ProductFeature  : UniquelyIdentifiable, AccessControlledObject 
		{
						EstimatedProductCost EstimatedProductCosts {set;}

						PriceComponent BasePrices {set;}

						global::System.String Description {set;}

						ProductFeature DependentFeatures {set;}

						ProductFeature IncompatibleFeatures {set;}

						VatRate VatRate {set;}

		}
		public interface Quote  : Transitional, Printable, Auditable, Commentable 
		{
						global::System.String InternalComment {set;}

						global::System.DateTime? RequiredResponseDate {set;}

						global::System.DateTime? ValidFromDate {set;}

						QuoteTerm QuoteTerms {set;}

						Party Issuer {set;}

						global::System.DateTime? ValidThroughDate {set;}

						global::System.String Description {set;}

						Party Receiver {set;}

						ContactMechanism FullfillContactMechanism {set;}

						global::System.Decimal? Amount {set;}

						Currency Currency {set;}

						global::System.DateTime IssueDate {set;}

						QuoteItem QuoteItems {set;}

						global::System.String QuoteNumber {set;}

						QuoteObjectState CurrentObjectState {set;}

						Request Request {set;}

		}
		public interface Request  : Transitional, Commentable, Auditable, Printable 
		{
						RequestObjectState CurrentObjectState {set;}

						global::System.String InternalComment {set;}

						global::System.String Description {set;}

						global::System.DateTime RequestDate {set;}

						global::System.DateTime? RequiredResponseDate {set;}

						RequestItem RequestItems {set;}

						global::System.String RequestNumber {set;}

						RespondingParty RespondingParties {set;}

						Party Originator {set;}

						Currency Currency {set;}

						ContactMechanism FullfillContactMechanism {set;}

						global::System.String EmailAddress {set;}

						global::System.String TelephoneNumber {set;}

						global::System.String TelephoneCountryCode {set;}

		}
		public interface Requirement  : Transitional, UniquelyIdentifiable 
		{
						global::System.DateTime? RequiredByDate {set;}

						Party Authorizer {set;}

						RequirementStatus RequirementStatuses {set;}

						global::System.String Reason {set;}

						Requirement Children {set;}

						Party NeededFor {set;}

						Party Originator {set;}

						RequirementObjectState CurrentObjectState {set;}

						RequirementStatus CurrentRequirementStatus {set;}

						Facility Facility {set;}

						Party ServicedBy {set;}

						global::System.Decimal? EstimatedBudget {set;}

						global::System.String Description {set;}

						global::System.Int32? Quantity {set;}

		}
		public interface Service  : Product 
		{
		}
		public interface ServiceEntry  : Commentable, AccessControlledObject 
		{
						global::System.DateTime? ThroughDateTime {set;}

						EngagementItem EngagementItem {set;}

						global::System.Boolean? IsBillable {set;}

						global::System.DateTime? FromDateTime {set;}

						global::System.String Description {set;}

						WorkEffort WorkEffort {set;}

		}
		public interface Shipment  : Printable, Transitional 
		{
						ShipmentMethod ShipmentMethod {set;}

						ContactMechanism BillToContactMechanism {set;}

						ShipmentPackage ShipmentPackages {set;}

						global::System.String ShipmentNumber {set;}

						Document Documents {set;}

						Party BillToParty {set;}

						Party ShipToParty {set;}

						ShipmentItem ShipmentItems {set;}

						ContactMechanism ReceiverContactMechanism {set;}

						PostalAddress ShipToAddress {set;}

						global::System.Decimal? EstimatedShipCost {set;}

						global::System.DateTime? EstimatedShipDate {set;}

						global::System.DateTime? LatestCancelDate {set;}

						Carrier Carrier {set;}

						ContactMechanism InquireAboutContactMechanism {set;}

						global::System.DateTime? EstimatedReadyDate {set;}

						PostalAddress ShipFromAddress {set;}

						ContactMechanism BillFromContactMechanism {set;}

						global::System.String HandlingInstruction {set;}

						Store Store {set;}

						Party ShipFromParty {set;}

						ShipmentRouteSegment ShipmentRouteSegments {set;}

						global::System.DateTime? EstimatedArrivalDate {set;}

		}
		public interface WorkEffortVersion  : Version 
		{
						SecurityToken OwnerSecurityToken {set;}

						AccessControl OwnerAccessControl {set;}

						global::System.String Name {set;}

						global::System.String Description {set;}

						WorkEffortObjectState CurrentObjectState {set;}

						Priority Priority {set;}

						WorkEffortPurpose WorkEffortPurposes {set;}

						global::System.DateTime? ActualCompletion {set;}

						global::System.DateTime? ScheduledStart {set;}

						global::System.DateTime? ScheduledCompletion {set;}

						global::System.Decimal? ActualHours {set;}

						global::System.Decimal? EstimatedHours {set;}

						WorkEffort Precendencies {set;}

						Facility Facility {set;}

						Deliverable DeliverablesProduced {set;}

						global::System.DateTime? ActualStart {set;}

						WorkEffortInventoryAssignment InventoryItemsNeeded {set;}

						WorkEffort Children {set;}

						OrderItem OrderItemFulfillment {set;}

						WorkEffortType WorkEffortType {set;}

						InventoryItem InventoryItemsProduced {set;}

						Requirement RequirementFulfillments {set;}

						global::System.String SpecialTerms {set;}

						WorkEffort Concurrencies {set;}

		}
		public interface WorkEffort  : Transitional, UniquelyIdentifiable, Deletable, Auditable 
		{
						SecurityToken OwnerSecurityToken {set;}

						AccessControl OwnerAccessControl {set;}

						Person Owner {set;}

						global::System.String Name {set;}

						global::System.String Description {set;}

						WorkEffortObjectState CurrentObjectState {set;}

						Priority Priority {set;}

						WorkEffortPurpose WorkEffortPurposes {set;}

						global::System.DateTime? ActualCompletion {set;}

						global::System.DateTime? ScheduledStart {set;}

						global::System.DateTime? ScheduledCompletion {set;}

						global::System.Decimal? ActualHours {set;}

						global::System.Decimal? EstimatedHours {set;}

						WorkEffort Precendencies {set;}

						Facility Facility {set;}

						Deliverable DeliverablesProduced {set;}

						global::System.DateTime? ActualStart {set;}

						WorkEffortInventoryAssignment InventoryItemsNeeded {set;}

						WorkEffort Children {set;}

						OrderItem OrderItemFulfillment {set;}

						WorkEffortType WorkEffortType {set;}

						InventoryItem InventoryItemsProduced {set;}

						Requirement RequirementFulfillments {set;}

						global::System.String SpecialTerms {set;}

						WorkEffort Concurrencies {set;}

		}
		public interface Counter  : UniquelyIdentifiable 
		{
						global::System.Int32 Value {set;}

		}
		public interface Singleton  : AccessControlledObject 
		{
						Locale DefaultLocale {set;}

						Locale Locales {set;}

						User Guest {set;}

						SecurityToken InitialSecurityToken {set;}

						SecurityToken DefaultSecurityToken {set;}

						AccessControl CreatorsAccessControl {set;}

						AccessControl GuestAccessControl {set;}

						AccessControl AdministratorsAccessControl {set;}

						PrintQueue DefaultPrintQueue {set;}

						SecurityToken AdministratorSecurityToken {set;}

						Currency DefaultCurrency {set;}

						Media NoImageAvailableImage {set;}

		}
		public interface Media  : UniquelyIdentifiable, AccessControlledObject, Deletable 
		{
						global::System.Guid? Revision {set;}

						MediaContent MediaContent {set;}

						global::System.Byte[] InData {set;}

						global::System.String InDataUri {set;}

						global::System.String FileName {set;}

						global::System.String Type {set;}

		}
		public interface MediaContent  : AccessControlledObject, Deletable 
		{
						global::System.String Type {set;}

						global::System.Byte[] Data {set;}

		}
		public interface Country  : GeographicBoundary, CityBound 
		{
						Currency Currency {set;}

						global::System.String IsoCode {set;}

						global::System.String Name {set;}

						LocalisedText LocalisedNames {set;}

						VatRate VatRates {set;}

						global::System.Int32? IbanLength {set;}

						global::System.Boolean? EuMemberState {set;}

						global::System.String TelephoneCode {set;}

						global::System.String IbanRegex {set;}

						VatForm VatForm {set;}

						global::System.String UriExtension {set;}

		}
		public interface Currency  : IUnitOfMeasure 
		{
						global::System.String IsoCode {set;}

						global::System.String Name {set;}

						LocalisedText LocalisedNames {set;}

		}
		public interface Language  : AccessControlledObject 
		{
						global::System.String IsoCode {set;}

						global::System.String Name {set;}

						global::System.String NativeName {set;}

						LocalisedText LocalisedNames {set;}

		}
		public interface Locale  : AccessControlledObject 
		{
						global::System.String Name {set;}

						Language Language {set;}

						Country Country {set;}

		}
		public interface LocalisedText  : AccessControlledObject, Localised 
		{
						global::System.String Text {set;}

		}
		public interface AccessControl  : Deletable, AccessControlledObject 
		{
						UserGroup SubjectGroups {set;}

						User Subjects {set;}

						Role Role {set;}

						Permission EffectivePermissions {set;}

						User EffectiveUsers {set;}

		}
		public interface Login  : Deletable 
		{
						global::System.String Key {set;}

						global::System.String Provider {set;}

						User User {set;}

		}
		public interface Permission  : Deletable, AccessControlledObject 
		{
						global::System.Guid OperandTypePointer {set;}

						global::System.Guid ConcreteClassPointer {set;}

						global::System.Int32 OperationEnum {set;}

		}
		public interface Role  : AccessControlledObject, UniquelyIdentifiable 
		{
						Permission Permissions {set;}

						global::System.String Name {set;}

		}
		public interface SecurityToken  : Deletable 
		{
						AccessControl AccessControls {set;}

		}
		public interface AutomatedAgent  : User, Party 
		{
						global::System.String Name {set;}

						global::System.String Description {set;}

		}
		public interface EmailMessage  : Object 
		{
						global::System.DateTime DateCreated {set;}

						global::System.DateTime? DateSending {set;}

						global::System.DateTime? DateSent {set;}

						User Sender {set;}

						User Recipients {set;}

						global::System.String Subject {set;}

						global::System.String Body {set;}

		}
		public interface Notification  : AccessControlledObject 
		{
						UniquelyIdentifiable Target {set;}

						global::System.Boolean Confirmed {set;}

						global::System.String Title {set;}

						global::System.String Description {set;}

						global::System.DateTime DateCreated {set;}

		}
		public interface NotificationList  : AccessControlledObject, Deletable 
		{
						Notification Notifications {set;}

						Notification UnconfirmedNotifications {set;}

						Notification ConfirmedNotifications {set;}

		}
		public interface Person  : User, Party, Deletable 
		{
						global::System.String FirstName {set;}

						global::System.String LastName {set;}

						global::System.String MiddleName {set;}

						PersonRole PersonRoles {set;}

						Salutation Salutation {set;}

						global::System.Decimal? YTDCommission {set;}

						PersonClassification PersonClassifications {set;}

						Citizenship Citizenship {set;}

						global::System.Decimal? LastYearsCommission {set;}

						global::System.String GivenName {set;}

						PersonalTitle Titles {set;}

						global::System.String MothersMaidenName {set;}

						global::System.DateTime? BirthDate {set;}

						global::System.Decimal? Height {set;}

						PersonTraining PersonTrainings {set;}

						GenderType Gender {set;}

						global::System.Int32? Weight {set;}

						Hobby Hobbies {set;}

						global::System.Int32? TotalYearsWorkExperience {set;}

						Passport Passports {set;}

						MaritalStatus MaritalStatus {set;}

						Media Picture {set;}

						global::System.String SocialSecurityNumber {set;}

						global::System.DateTime? DeceasedDate {set;}

						global::System.String Function {set;}

						PayrollPreference PayrollPreferences {set;}

						EmploymentTerminationReason EmploymentTerminationReason {set;}

						EmploymentTermination EmploymentTermination {set;}

		}
		public interface TaskAssignment  : AccessControlledObject, Deletable 
		{
						User User {set;}

						Notification Notification {set;}

						Task Task {set;}

		}
		public interface TaskList  : Deletable 
		{
						TaskAssignment TaskAssignments {set;}

						TaskAssignment OpenTaskAssignments {set;}

						global::System.Int32? Count {set;}

		}
		public interface UserGroup  : UniquelyIdentifiable, AccessControlledObject 
		{
						User Members {set;}

						global::System.String Name {set;}

		}
		public interface AccountAdjustment  : FinancialAccountTransaction 
		{
		}
		public interface AccountingPeriod  : Budget 
		{
						AccountingPeriod Parent {set;}

						global::System.Boolean Active {set;}

						global::System.Int32 PeriodNumber {set;}

						TimeFrequency TimeFrequency {set;}

		}
		public interface AccountingTransactionDetail  : AccessControlledObject 
		{
						AccountingTransactionDetail AssociatedWith {set;}

						OrganisationGlAccountBalance OrganisationGlAccountBalance {set;}

						global::System.Decimal Amount {set;}

						global::System.Boolean Debit {set;}

		}
		public interface AccountingTransactionNumber  : AccessControlledObject 
		{
						global::System.Int32? Number {set;}

						global::System.Int32? Year {set;}

						AccountingTransactionType AccountingTransactionType {set;}

		}
		public interface AccountingTransactionType  : Enumeration 
		{
		}
		public interface Activity  : WorkEffort, Versioned 
		{
						ActivityVersion CurrentVersion {set;}

						ActivityVersion AllVersions {set;}

		}
		public interface ActivityUsage  : DeploymentUsage 
		{
						global::System.Decimal Quantity {set;}

						UnitOfMeasure UnitOfMeasure {set;}

		}
		public interface ActivityVersion  : WorkEffortVersion 
		{
		}
		public interface Addendum  : AccessControlledObject 
		{
						global::System.String Text {set;}

						global::System.DateTime? EffictiveDate {set;}

						global::System.String Description {set;}

						global::System.DateTime CreationDate {set;}

		}
		public interface AgreementExhibit  : AgreementItem 
		{
		}
		public interface AgreementPricingProgram  : AgreementItem 
		{
		}
		public interface AgreementSection  : AgreementItem 
		{
		}
		public interface Amortization  : InternalAccountingTransaction 
		{
		}
		public interface AmountDue  : AccessControlledObject 
		{
						global::System.Decimal? Amount {set;}

						PaymentMethod PaymentMethod {set;}

						global::System.DateTime? TransactionDate {set;}

						global::System.DateTime? BlockedForDunning {set;}

						global::System.Decimal? AmountVat {set;}

						BankAccount BankAccount {set;}

						global::System.DateTime? ReconciliationDate {set;}

						global::System.String InvoiceNumber {set;}

						global::System.Int32? DunningStep {set;}

						global::System.Int32? SubAccountNumber {set;}

						global::System.String TransactionNumber {set;}

						DebitCreditConstant Side {set;}

						Currency Currency {set;}

						global::System.Boolean? BlockedForPayment {set;}

						global::System.DateTime? DateLastReminder {set;}

						global::System.String YourReference {set;}

						global::System.String OurReference {set;}

						global::System.String ReconciliationNumber {set;}

						global::System.DateTime? DueDate {set;}

		}
		public interface AssetAssignmentStatus  : Enumeration 
		{
		}
		public interface Bank  : AccessControlledObject 
		{
						Media Logo {set;}

						global::System.String Bic {set;}

						global::System.String SwiftCode {set;}

						Country Country {set;}

						global::System.String Name {set;}

		}
		public interface BankAccount  : FinancialAccount 
		{
						Bank Bank {set;}

						global::System.String NameOnAccount {set;}

						ContactMechanism ContactMechanisms {set;}

						Currency Currency {set;}

						global::System.String Iban {set;}

						global::System.String Branch {set;}

						Person ContactPersons {set;}

		}
		public interface Barrel  : Container 
		{
		}
		public interface BasePrice  : Deletable, PriceComponent 
		{
		}
		public interface Benefit  : AccessControlledObject 
		{
						global::System.Decimal? EmployerPaidPercentage {set;}

						global::System.String Description {set;}

						global::System.String Name {set;}

						global::System.Decimal? AvailableTime {set;}

		}
		public interface BillingAccount  : AccessControlledObject 
		{
						global::System.String Description {set;}

						ContactMechanism ContactMechanism {set;}

		}
		public interface BillOfLading  : Document 
		{
		}
		public interface Bin  : Container 
		{
		}
		public interface Brand  : ProductFeature 
		{
						global::System.String Name {set;}

						ProductCategory ProductCategories {set;}

						Model Models {set;}

		}
		public interface BudgetItem  : AccessControlledObject 
		{
						global::System.String Purpose {set;}

						global::System.String Justification {set;}

						BudgetItem Children {set;}

						global::System.Decimal Amount {set;}

		}
		public interface BudgetObjectState  : ObjectState 
		{
		}
		public interface BudgetReview  : Commentable, AccessControlledObject 
		{
						global::System.DateTime ReviewDate {set;}

						global::System.String Description {set;}

		}
		public interface BudgetRevision  : AccessControlledObject 
		{
						global::System.DateTime RevisionDate {set;}

		}
		public interface BudgetRevisionImpact  : AccessControlledObject 
		{
						BudgetItem BudgetItem {set;}

						global::System.String Reason {set;}

						global::System.Boolean? Deleted {set;}

						global::System.Boolean? Added {set;}

						global::System.Decimal? RevisedAmount {set;}

						BudgetRevision BudgetRevision {set;}

		}
		public interface BudgetStatus  : AccessControlledObject 
		{
						global::System.DateTime StartDateTime {set;}

						BudgetObjectState BudgetObjectState {set;}

		}
		public interface Building  : Facility 
		{
		}
		public interface CapitalBudget  : Budget 
		{
		}
		public interface Capitalization  : InternalAccountingTransaction 
		{
		}
		public interface Carrier  : UniquelyIdentifiable, AccessControlledObject 
		{
						global::System.String Name {set;}

		}
		public interface Case  : Transitional, UniquelyIdentifiable 
		{
						CaseStatus CurrentCaseStatus {set;}

						CaseStatus CaseStatuses {set;}

						global::System.DateTime? StartDate {set;}

						CaseObjectState CurrentObjectState {set;}

						global::System.String Description {set;}

		}
		public interface CaseObjectState  : ObjectState 
		{
		}
		public interface CaseStatus  : AccessControlledObject 
		{
						global::System.DateTime StartDateTime {set;}

						CaseObjectState CaseObjectState {set;}

		}
		public interface Cash  : PaymentMethod 
		{
						Person PersonResponsible {set;}

		}
		public interface Catalogue  : AccessControlledObject, UniquelyIdentifiable 
		{
						Media NoImageAvailableImage {set;}

						global::System.String Name {set;}

						global::System.String Description {set;}

						LocalisedText LocalisedNames {set;}

						LocalisedText LocalisedDescriptions {set;}

						Media CatalogueImage {set;}

						ProductCategory ProductCategories {set;}

						CatScope CatScope {set;}

		}
		public interface CatScope  : Enumeration 
		{
		}
		public interface ChartOfAccounts  : UniquelyIdentifiable, AccessControlledObject 
		{
						global::System.String Name {set;}

						GeneralLedgerAccount GeneralLedgerAccounts {set;}

		}
		public interface Citizenship  : AccessControlledObject 
		{
						Passport Passports {set;}

						Country Country {set;}

		}
		public interface City  : GeographicBoundary, CountryBound 
		{
						global::System.String Name {set;}

						State State {set;}

		}
		public interface ClientAgreement  : Agreement 
		{
		}
		public interface Colour  : Enumeration, ProductFeature 
		{
		}
		public interface CommunicationEventObjectState  : ObjectState 
		{
		}
		public interface CommunicationEventPurpose  : Enumeration 
		{
		}
		public interface CommunicationEventStatus  : Deletable, AccessControlledObject 
		{
						global::System.DateTime StartDateTime {set;}

						CommunicationEventObjectState CommunicationEventObjectState {set;}

		}
		public interface ConstraintSpecification  : PartSpecification 
		{
		}
		public interface ContactMechanismPurpose  : Enumeration 
		{
		}
		public interface ContactMechanismType  : Enumeration 
		{
		}
		public interface CostCenter  : AccessControlledObject, UniquelyIdentifiable 
		{
						global::System.String Description {set;}

						OrganisationGlAccount InternalTransferGlAccount {set;}

						CostCenterCategory CostCenterCategories {set;}

						OrganisationGlAccount RedistributedCostsGlAccount {set;}

						global::System.String Name {set;}

						global::System.Boolean? Active {set;}

						global::System.Boolean? UseGlAccountOfBooking {set;}

		}
		public interface CostCenterCategory  : UniquelyIdentifiable 
		{
						CostCenterCategory Parent {set;}

						CostCenterCategory Ancestors {set;}

						CostCenterCategory Children {set;}

						global::System.String Description {set;}

		}
		public interface CostCenterSplitMethod  : Enumeration 
		{
		}
		public interface CostOfGoodsSoldMethod  : Enumeration 
		{
		}
		public interface County  : GeographicBoundary, CityBound 
		{
						global::System.String Name {set;}

						State State {set;}

		}
		public interface CreditCard  : FinancialAccount 
		{
						global::System.String NameOnCard {set;}

						CreditCardCompany CreditCardCompany {set;}

						global::System.Int32 ExpirationYear {set;}

						global::System.Int32 ExpirationMonth {set;}

						global::System.String CardNumber {set;}

		}
		public interface CreditCardCompany  : AccessControlledObject 
		{
						global::System.String Name {set;}

		}
		public interface CreditLine  : ExternalAccountingTransaction 
		{
		}
		public interface CustomEngagementItem  : EngagementItem 
		{
						global::System.String DescriptionOfWork {set;}

						global::System.Decimal? AgreedUponPrice {set;}

		}
		public interface CustomerRequirement  : Requirement 
		{
		}
		public interface CustomerReturn  : Shipment 
		{
						CustomerReturnStatus CurrentShipmentStatus {set;}

						CustomerReturnStatus ShipmentStatuses {set;}

						CustomerReturnObjectState CurrentObjectState {set;}

		}
		public interface CustomerReturnObjectState  : ObjectState 
		{
		}
		public interface CustomerReturnStatus  : AccessControlledObject 
		{
						global::System.DateTime StartDateTime {set;}

						ShipmentReceipt ShipmentReceipt {set;}

						CustomerReturnObjectState CustomerReturnObjectState {set;}

		}
		public interface CustomerShipment  : Deletable, Shipment 
		{
						CustomerShipmentStatus CurrentShipmentStatus {set;}

						global::System.Boolean ReleasedManually {set;}

						CustomerShipmentObjectState CurrentObjectState {set;}

						CustomerShipmentStatus ShipmentStatuses {set;}

						PaymentMethod PaymentMethod {set;}

						global::System.Boolean WithoutCharges {set;}

						global::System.Boolean HeldManually {set;}

						global::System.Decimal ShipmentValue {set;}

		}
		public interface CustomerShipmentObjectState  : ObjectState 
		{
		}
		public interface CustomerShipmentStatus  : AccessControlledObject 
		{
						CustomerShipmentObjectState CustomerShipmentObjectState {set;}

						global::System.DateTime StartDateTime {set;}

		}
		public interface CustomOrganisationClassification  : OrganisationClassification 
		{
		}
		public interface DebitCreditConstant  : Enumeration 
		{
		}
		public interface Deduction  : AccessControlledObject 
		{
						DeductionType DeductionType {set;}

						global::System.Decimal Amount {set;}

		}
		public interface DeductionType  : Enumeration 
		{
		}
		public interface Deliverable  : AccessControlledObject 
		{
						global::System.String Name {set;}

						DeliverableType DeliverableType {set;}

		}
		public interface DeliverableBasedService  : Service 
		{
		}
		public interface DeliverableOrderItem  : EngagementItem 
		{
						global::System.Decimal? AgreedUponPrice {set;}

		}
		public interface DeliverableTurnover  : ServiceEntry 
		{
						global::System.Decimal Amount {set;}

		}
		public interface DeliverableType  : Enumeration 
		{
		}
		public interface Deployment  : AccessControlledObject, Period 
		{
						Good ProductOffering {set;}

						DeploymentUsage DeploymentUsage {set;}

						SerialisedInventoryItem SerializedInventoryItem {set;}

		}
		public interface Deposit  : FinancialAccountTransaction 
		{
						Receipt Receipts {set;}

		}
		public interface Depreciation  : InternalAccountingTransaction 
		{
						FixedAsset FixedAsset {set;}

		}
		public interface DepreciationMethod  : AccessControlledObject 
		{
						global::System.String Formula {set;}

						global::System.String Description {set;}

		}
		public interface DesiredProductFeature  : AccessControlledObject 
		{
						global::System.Boolean Required {set;}

						ProductFeature ProductFeature {set;}

		}
		public interface Dimension  : ProductFeature 
		{
						global::System.Decimal? Unit {set;}

						UnitOfMeasure UnitOfMeasure {set;}

		}
		public interface Disbursement  : Payment 
		{
		}
		public interface DisbursementAccountingTransaction  : ExternalAccountingTransaction 
		{
						Disbursement Disbursement {set;}

		}
		public interface DiscountAdjustmentVersion  : OrderAdjustmentVersion 
		{
		}
		public interface DiscountAdjustment  : OrderAdjustment, Versioned 
		{
						DiscountAdjustmentVersion CurrentVersion {set;}

						DiscountAdjustmentVersion AllVersions {set;}

		}
		public interface DiscountComponent  : PriceComponent 
		{
						global::System.Decimal? Percentage {set;}

		}
		public interface DropShipment  : Shipment 
		{
						DropShipmentStatus ShipmentStatuses {set;}

						DropShipmentStatus CurrentShipmentStatus {set;}

						DropShipmentObjectState CurrentObjectState {set;}

		}
		public interface DropShipmentObjectState  : ObjectState 
		{
		}
		public interface DropShipmentStatus  : AccessControlledObject 
		{
						global::System.DateTime StartDateTime {set;}

						DropShipmentObjectState DropShipmentObjectState {set;}

		}
		public interface DunningType  : Enumeration 
		{
		}
		public interface EmailAddress  : ElectronicAddress 
		{
		}
		public interface EmailCommunication  : CommunicationEvent, Versioned 
		{
						EmailAddress Originator {set;}

						EmailAddress Addressees {set;}

						EmailAddress CarbonCopies {set;}

						EmailAddress BlindCopies {set;}

						EmailTemplate EmailTemplate {set;}

						global::System.Boolean IncomingMail {set;}

						EmailCommunicationVersion CurrentVersion {set;}

						EmailCommunicationVersion AllVersions {set;}

		}
		public interface EmailCommunicationVersion  : CommunicationEventVersion 
		{
						EmailAddress Originator {set;}

						EmailAddress Addressees {set;}

						EmailAddress CarbonCopies {set;}

						EmailAddress BlindCopies {set;}

						EmailTemplate EmailTemplate {set;}

						global::System.Boolean IncomingMail {set;}

		}
		public interface EmailTemplate  : AccessControlledObject 
		{
						global::System.String Description {set;}

						global::System.String BodyTemplate {set;}

						global::System.String SubjectTemplate {set;}

		}
		public interface EmploymentAgreement  : Agreement 
		{
		}
		public interface EmploymentApplication  : AccessControlledObject 
		{
						global::System.DateTime ApplicationDate {set;}

						Position Position {set;}

						EmploymentApplicationStatus EmploymentApplicationStatus {set;}

						Person Person {set;}

						EmploymentApplicationSource EmploymentApplicationSource {set;}

		}
		public interface EmploymentApplicationSource  : Enumeration 
		{
		}
		public interface EmploymentApplicationStatus  : Enumeration 
		{
		}
		public interface EmploymentTermination  : Enumeration 
		{
		}
		public interface EmploymentTerminationReason  : Enumeration 
		{
		}
		public interface Engagement  : AccessControlledObject 
		{
						Agreement Agreement {set;}

						ContactMechanism PlacingContactMechanism {set;}

						global::System.Decimal? MaximumAmount {set;}

						ContactMechanism BillToContactMechanism {set;}

						global::System.String Description {set;}

						Party BillToParty {set;}

						Party PlacingParty {set;}

						global::System.DateTime? StartDate {set;}

						ContactMechanism TakenViaContactMechanism {set;}

						global::System.Decimal? EstimatedAmount {set;}

						global::System.DateTime? EndDate {set;}

						global::System.DateTime? ContractDate {set;}

						EngagementItem EngagementItems {set;}

						global::System.String ClientPurchaseOrderNumber {set;}

						OrganisationContactRelationship TakenViaOrganisationContactRelationship {set;}

		}
		public interface EngagementRate  : Period, AccessControlledObject 
		{
						global::System.Decimal BillingRate {set;}

						RatingType RatingType {set;}

						global::System.Decimal? Cost {set;}

						PriceComponent GoverningPriceComponents {set;}

						global::System.String ChangeReason {set;}

						UnitOfMeasure UnitOfMeasure {set;}

		}
		public interface EngineeringBom  : PartBillOfMaterial 
		{
		}
		public interface EngineeringChange  : Transitional 
		{
						Person Requestor {set;}

						Person Authorizer {set;}

						global::System.String Description {set;}

						Person Designer {set;}

						PartSpecification PartSpecifications {set;}

						PartBillOfMaterial PartBillOfMaterials {set;}

						EngineeringChangeObjectState CurrentObjectState {set;}

						EngineeringChangeStatus EngineeringChangeStatuses {set;}

						Person Tester {set;}

						EngineeringChangeStatus CurrentEngineeringChangeStatus {set;}

		}
		public interface EngineeringChangeObjectState  : ObjectState 
		{
		}
		public interface EngineeringChangeStatus  : AccessControlledObject 
		{
						global::System.DateTime StartDateTime {set;}

						EngineeringChangeObjectState EngineeringChangeObjectState {set;}

		}
		public interface EngineeringDocument  : Document 
		{
		}
		public interface Equipment  : FixedAsset 
		{
		}
		public interface EstimatedLaborCost  : EstimatedProductCost 
		{
		}
		public interface EstimatedMaterialCost  : EstimatedProductCost 
		{
		}
		public interface EstimatedOtherCost  : EstimatedProductCost 
		{
		}
		public interface EuSalesListType  : Enumeration 
		{
		}
		public interface Event  : Object 
		{
						global::System.Boolean? RegistrationRequired {set;}

						global::System.String Link {set;}

						global::System.String Location {set;}

						global::System.String Text {set;}

						global::System.String AnnouncementText {set;}

						global::System.DateTime? From {set;}

						Locale Locale {set;}

						global::System.String Title {set;}

						Media Photo {set;}

						global::System.Boolean? Announce {set;}

						global::System.DateTime? To {set;}

		}
		public interface EventRegistration  : Object 
		{
						Person Person {set;}

						Event Event {set;}

						global::System.DateTime? AllorsDateTime {set;}

		}
		public interface ExpenseEntry  : ServiceEntry 
		{
						global::System.Decimal Amount {set;}

		}
		public interface ExportDocument  : Document 
		{
		}
		public interface FaceToFaceCommunication  : CommunicationEvent, Versioned 
		{
						Party Participants {set;}

						global::System.String Location {set;}

						FaceToFaceCommunicationVersion CurrentVersion {set;}

						FaceToFaceCommunicationVersion AllVersions {set;}

		}
		public interface FaceToFaceCommunicationVersion  : CommunicationEventVersion 
		{
						Party Participants {set;}

						global::System.String Location {set;}

		}
		public interface FaxCommunication  : CommunicationEvent, Versioned 
		{
						Party Originator {set;}

						Party Receiver {set;}

						TelecommunicationsNumber OutgoingFaxNumber {set;}

						FaxCommunicationVersion CurrentVersion {set;}

						FaxCommunicationVersion AllVersions {set;}

		}
		public interface FaxCommunicationVersion  : CommunicationEventVersion 
		{
						Party Originator {set;}

						Party Receiver {set;}

						TelecommunicationsNumber OutgoingFaxNumber {set;}

		}
		public interface Fee  : OrderAdjustment 
		{
		}
		public interface FinancialAccountAdjustment  : FinancialAccountTransaction 
		{
		}
		public interface FinancialTerm  : AgreementTerm 
		{
		}
		public interface FinishedGood  : Part 
		{
		}
		public interface FiscalYearInvoiceNumber  : Object 
		{
						global::System.Int32 NextSalesInvoiceNumber {set;}

						global::System.Int32 FiscalYear {set;}

		}
		public interface Floor  : Facility 
		{
		}
		public interface GenderType  : Enumeration 
		{
		}
		public interface GeneralLedgerAccount  : UniquelyIdentifiable, AccessControlledObject 
		{
						Product DefaultCostUnit {set;}

						CostCenter DefaultCostCenter {set;}

						global::System.String Description {set;}

						GeneralLedgerAccountType GeneralLedgerAccountType {set;}

						global::System.Boolean CashAccount {set;}

						global::System.Boolean CostCenterAccount {set;}

						DebitCreditConstant Side {set;}

						global::System.Boolean BalanceSheetAccount {set;}

						global::System.Boolean ReconciliationAccount {set;}

						global::System.String Name {set;}

						global::System.Boolean CostCenterRequired {set;}

						global::System.Boolean CostUnitRequired {set;}

						GeneralLedgerAccountGroup GeneralLedgerAccountGroup {set;}

						CostCenter CostCentersAllowed {set;}

						global::System.Boolean CostUnitAccount {set;}

						global::System.String AccountNumber {set;}

						Product CostUnitsAllowed {set;}

						global::System.Boolean Protected {set;}

		}
		public interface GeneralLedgerAccountGroup  : AccessControlledObject 
		{
						GeneralLedgerAccountGroup Parent {set;}

						global::System.String Description {set;}

		}
		public interface GeneralLedgerAccountType  : AccessControlledObject 
		{
						global::System.String Description {set;}

		}
		public interface GlBudgetAllocation  : AccessControlledObject 
		{
						GeneralLedgerAccount GeneralLedgerAccount {set;}

						BudgetItem BudgetItem {set;}

						global::System.Decimal AllocationPercentage {set;}

		}
		public interface Good  : Product, Deletable 
		{
						global::System.Decimal QuantityOnHand {set;}

						global::System.Decimal AvailableToPromise {set;}

						Media Thumbnail {set;}

						InventoryItemKind InventoryItemKind {set;}

						global::System.String BarCode {set;}

						FinishedGood FinishedGood {set;}

						global::System.String Sku {set;}

						global::System.String ArticleNumber {set;}

						Party ManufacturedBy {set;}

						global::System.String ManufacturerId {set;}

						Party SuppliedBy {set;}

						Product ProductSubstitutions {set;}

						Product ProductIncompatibilities {set;}

						Media PrimaryPhoto {set;}

						Media Photos {set;}

						global::System.String Keywords {set;}

		}
		public interface GoodOrderItem  : EngagementItem 
		{
						global::System.Decimal? Price {set;}

						global::System.Int32? Quantity {set;}

		}
		public interface HazardousMaterialsDocument  : Document 
		{
		}
		public interface Hobby  : Enumeration 
		{
		}
		public interface Incentive  : AgreementTerm 
		{
		}
		public interface IndustryClassification  : OrganisationClassification 
		{
		}
		public interface InternalOrganisation  : UniquelyIdentifiable, Auditable 
		{
						global::System.String PurchaseOrderNumberPrefix {set;}

						global::System.String TransactionReferenceNumber {set;}

						JournalEntryNumber JournalEntryNumbers {set;}

						Country EuListingState {set;}

						Counter PurchaseInvoiceCounter {set;}

						AccountingPeriod ActualAccountingPeriod {set;}

						InvoiceSequence InvoiceSequence {set;}

						PaymentMethod ActivePaymentMethods {set;}

						global::System.Decimal? MaximumAllowedPaymentDifference {set;}

						Media LogoImage {set;}

						CostCenterSplitMethod CostCenterSplitMethod {set;}

						Counter PurchaseOrderCounter {set;}

						LegalForm LegalForm {set;}

						AccountingPeriod AccountingPeriods {set;}

						GeneralLedgerAccount SalesPaymentDifferencesAccount {set;}

						global::System.String Name {set;}

						global::System.String PurchaseTransactionReferenceNumber {set;}

						global::System.Int32 FiscalYearStartMonth {set;}

						CostOfGoodsSoldMethod CostOfGoodsSoldMethod {set;}

						Role EmployeeRoles {set;}

						global::System.Boolean? VatDeactivated {set;}

						global::System.Int32 FiscalYearStartDay {set;}

						GeneralLedgerAccount GeneralLedgerAccounts {set;}

						Counter AccountingTransactionCounter {set;}

						Counter IncomingShipmentCounter {set;}

						GeneralLedgerAccount RetainedEarningsAccount {set;}

						Party Customers {set;}

						global::System.String PurchaseInvoiceNumberPrefix {set;}

						GeneralLedgerAccount SalesPaymentDiscountDifferencesAccount {set;}

						Counter SubAccountCounter {set;}

						AccountingTransactionNumber AccountingTransactionNumbers {set;}

						global::System.String TransactionReferenceNumberPrefix {set;}

						Counter QuoteCounter {set;}

						Counter RequestCounter {set;}

						Currency PreviousCurrency {set;}

						Person Employees {set;}

						GeneralLedgerAccount PurchasePaymentDifferencesAccount {set;}

						GeneralLedgerAccount SuspenceAccount {set;}

						GeneralLedgerAccount NetIncomeAccount {set;}

						global::System.Boolean DoAccounting {set;}

						Facility DefaultFacility {set;}

						GeneralLedgerAccount PurchasePaymentDiscountDifferencesAccount {set;}

						Party Suppliers {set;}

						global::System.String QuoteNumberPrefix {set;}

						global::System.String PurchaseTransactionReferenceNumberPrefix {set;}

						global::System.String TaxNumber {set;}

						GeneralLedgerAccount CalculationDifferencesAccount {set;}

						PaymentMethod PaymentMethods {set;}

						global::System.String IncomingShipmentNumberPrefix {set;}

						global::System.String RequestNumberPrefix {set;}

						Person CurrentSalesReps {set;}

						PartyContactMechanism PartyContactMechanisms {set;}

						BankAccount BankAccounts {set;}

						PaymentMethod DefaultPaymentMethod {set;}

						Currency PreferredCurrency {set;}

						VatRegime VatRegime {set;}

						Locale PreferredLocale {set;}

						Person SalesReps {set;}

						GeneralLedgerAccount GlAccount {set;}

						ContactMechanism BillingAddress {set;}

						ContactMechanism OrderAddress {set;}

						PostalAddress ShippingAddress {set;}

						ContactMechanism BillingInquiriesFax {set;}

						ContactMechanism BillingInquiriesPhone {set;}

						ContactMechanism CellPhoneNumber {set;}

						ContactMechanism GeneralFaxNumber {set;}

						ContactMechanism GeneralPhoneNumber {set;}

						ContactMechanism HeadQuarter {set;}

						ContactMechanism HomeAddress {set;}

						ContactMechanism InternetAddress {set;}

						ContactMechanism OrderInquiriesFax {set;}

						ContactMechanism OrderInquiriesPhone {set;}

						ContactMechanism PersonalEmailAddress {set;}

						ContactMechanism SalesOffice {set;}

						ContactMechanism ShippingInquiriesFax {set;}

						ContactMechanism ShippingInquiriesPhone {set;}

		}
		public interface InternalOrganisationRevenue  : AccessControlledObject, Deletable 
		{
						global::System.Int32 Month {set;}

						global::System.Int32 Year {set;}

						global::System.Decimal Revenue {set;}

						Currency Currency {set;}

		}
		public interface InternalOrganisationRevenueHistory  : AccessControlledObject 
		{
						global::System.Decimal? AllorsDecimal {set;}

						Currency Currency {set;}

						global::System.Decimal Revenue {set;}

		}
		public interface InternalRequirement  : Requirement 
		{
		}
		public interface InventoryItemKind  : Enumeration 
		{
		}
		public interface InventoryItemVariance  : AccessControlledObject, Commentable 
		{
						global::System.Int32 Quantity {set;}

						ItemVarianceAccountingTransaction ItemVarianceAccountingTransaction {set;}

						global::System.DateTime? InventoryDate {set;}

						VarianceReason Reason {set;}

		}
		public interface InvestmentAccount  : FinancialAccount 
		{
						global::System.String Name {set;}

		}
		public interface InvoiceSequence  : Enumeration 
		{
		}
		public interface InvoiceTerm  : AgreementTerm 
		{
		}
		public interface InvoiceVatRateItem  : AccessControlledObject 
		{
						global::System.Decimal? BaseAmount {set;}

						VatRate VatRates {set;}

						global::System.Decimal? VatAmount {set;}

		}
		public interface ItemIssuance  : Deletable, AccessControlledObject 
		{
						global::System.DateTime? IssuanceDateTime {set;}

						InventoryItem InventoryItem {set;}

						global::System.Decimal Quantity {set;}

						ShipmentItem ShipmentItem {set;}

						PickListItem PickListItem {set;}

		}
		public interface ItemVarianceAccountingTransaction  : AccountingTransaction 
		{
		}
		public interface Journal  : AccessControlledObject 
		{
						global::System.Boolean UseAsDefault {set;}

						OrganisationGlAccount GlPaymentInTransit {set;}

						JournalType JournalType {set;}

						global::System.String Description {set;}

						global::System.Boolean BlockUnpaidTransactions {set;}

						OrganisationGlAccount ContraAccount {set;}

						JournalType PreviousJournalType {set;}

						OrganisationGlAccount PreviousContraAccount {set;}

						JournalEntry JournalEntries {set;}

						global::System.Boolean CloseWhenInBalance {set;}

		}
		public interface JournalEntry  : Transitional 
		{
						global::System.String Description {set;}

						global::System.Int32? EntryNumber {set;}

						global::System.DateTime? EntryDate {set;}

						global::System.DateTime? JournalDate {set;}

						JournalEntryDetail JournalEntryDetails {set;}

		}
		public interface JournalEntryDetail  : AccessControlledObject 
		{
						OrganisationGlAccount GeneralLedgerAccount {set;}

						global::System.Decimal? Amount {set;}

						global::System.Boolean? Debit {set;}

		}
		public interface JournalEntryNumber  : AccessControlledObject 
		{
						JournalType JournalType {set;}

						global::System.Int32? Number {set;}

						global::System.Int32? Year {set;}

		}
		public interface JournalType  : Enumeration 
		{
		}
		public interface LegalForm  : AccessControlledObject 
		{
						global::System.String Description {set;}

		}
		public interface LegalTerm  : AgreementTerm 
		{
		}
		public interface LetterCorrespondence  : CommunicationEvent, Versioned 
		{
						PostalAddress PostalAddresses {set;}

						Party Originators {set;}

						Party Receivers {set;}

						global::System.Boolean IncomingLetter {set;}

						LetterCorrespondenceVersion CurrentVersion {set;}

						LetterCorrespondenceVersion AllVersions {set;}

		}
		public interface LetterCorrespondenceVersion  : CommunicationEventVersion 
		{
						PostalAddress PostalAddresses {set;}

						Party Originators {set;}

						Party Receivers {set;}

						global::System.Boolean IncomingLetter {set;}

		}
		public interface Lot  : AccessControlledObject 
		{
						global::System.DateTime? ExpirationDate {set;}

						global::System.Int32? Quantity {set;}

						global::System.String LotNumber {set;}

		}
		public interface Maintenance  : WorkEffort, Versioned 
		{
						MaintenanceVersion CurrentVersion {set;}

						MaintenanceVersion AllVersions {set;}

		}
		public interface MaintenanceVersion  : WorkEffortVersion 
		{
		}
		public interface Manifest  : Document 
		{
		}
		public interface ManufacturerSuggestedRetailPrice  : PriceComponent 
		{
		}
		public interface ManufacturingBom  : PartBillOfMaterial 
		{
		}
		public interface ManufacturingConfiguration  : InventoryItemConfiguration 
		{
		}
		public interface MaritalStatus  : Enumeration 
		{
		}
		public interface MarketingMaterial  : Document 
		{
		}
		public interface MarketingPackage  : ProductAssociation 
		{
						global::System.String Instruction {set;}

						Product ProductsUsedIn {set;}

						Product Product {set;}

						global::System.String Description {set;}

						global::System.Int32? QuantityUsed {set;}

		}
		public interface MaterialsUsage  : ServiceEntry 
		{
						global::System.Decimal Amount {set;}

		}
		public interface Model  : ProductFeature, Enumeration 
		{
		}
		public interface NeededSkill  : AccessControlledObject 
		{
						SkillLevel SkillLevel {set;}

						global::System.Decimal? YearsExperience {set;}

						Skill Skill {set;}

		}
		public interface NewsItem  : AccessControlledObject 
		{
						global::System.Boolean? IsPublished {set;}

						global::System.String Title {set;}

						global::System.Int32? DisplayOrder {set;}

						Locale Locale {set;}

						global::System.String LongText {set;}

						global::System.String Text {set;}

						global::System.DateTime? Date {set;}

						global::System.Boolean? Announcement {set;}

		}
		public interface NonSerialisedInventoryItem  : InventoryItem, Versioned 
		{
						global::System.Decimal QuantityCommittedOut {set;}

						global::System.Decimal QuantityOnHand {set;}

						global::System.Decimal PreviousQuantityOnHand {set;}

						global::System.Decimal AvailableToPromise {set;}

						global::System.Decimal QuantityExpectedIn {set;}

						NonSerialisedInventoryItemObjectState CurrentObjectState {set;}

						NonSerialisedInventoryItemVersion CurrentVersion {set;}

						NonSerialisedInventoryItemVersion AllVersions {set;}

		}
		public interface NonSerialisedInventoryItemObjectState  : ObjectState 
		{
		}
		public interface NonSerialisedInventoryItemVersion  : InventoryItemVersion 
		{
						global::System.Decimal QuantityCommittedOut {set;}

						global::System.Decimal QuantityOnHand {set;}

						global::System.Decimal PreviousQuantityOnHand {set;}

						global::System.Decimal AvailableToPromise {set;}

						global::System.Decimal QuantityExpectedIn {set;}

						NonSerialisedInventoryItemObjectState CurrentObjectState {set;}

		}
		public interface NonSerializedInventoryItemObjectState  : ObjectState 
		{
		}
		public interface NonSerializedInventoryItemStatus  : AccessControlledObject 
		{
						global::System.DateTime StartDateTime {set;}

						NonSerializedInventoryItemObjectState NonSerializedInventoryItemObjectState {set;}

		}
		public interface Ownership  : Enumeration 
		{
		}
		public interface PhaseVersion  : WorkEffortVersion 
		{
		}
		public interface PhoneCommunicationVersion  : CommunicationEventVersion 
		{
						global::System.Boolean? LeftVoiceMail {set;}

						global::System.Boolean IncomingCall {set;}

						Party Receivers {set;}

						Party Callers {set;}

		}
		public interface ProcessFlow  : Enumeration 
		{
		}
		public interface ProductionRunVersion  : WorkEffortVersion 
		{
						global::System.Int32? QuantityProduced {set;}

						global::System.Int32? QuantityRejected {set;}

						global::System.Int32? QuantityToProduce {set;}

		}
		public interface ProductQuoteVersion  : QuoteVersion 
		{
		}
		public interface ProgramVersion  : WorkEffortVersion 
		{
		}
		public interface ProjectVersion  : WorkEffortVersion 
		{
		}
		public interface ProposalVersion  : QuoteVersion 
		{
		}
		public interface PurchaseInvoiceItemVersion  : InvoiceItemVersion 
		{
						PurchaseInvoiceItemType PurchaseInvoiceItemType {set;}

						Part Part {set;}

						PurchaseInvoiceItemObjectState CurrentObjectState {set;}

		}
		public interface PurchaseInvoiceVersion  : InvoiceVersion 
		{
						PurchaseInvoiceItem PurchaseInvoiceItems {set;}

						PurchaseInvoiceObjectState CurrentObjectState {set;}

						Party BilledFromParty {set;}

						PurchaseInvoiceType PurchaseInvoiceType {set;}

		}
		public interface PurchaseOrderItemVersion  : OrderItemVersion 
		{
						PurchaseOrderItemObjectState CurrentObjectState {set;}

						global::System.Decimal QuantityReceived {set;}

						Product Product {set;}

						Part Part {set;}

		}
		public interface PurchaseOrderVersion  : OrderVersion 
		{
						PurchaseOrderItem PurchaseOrderItems {set;}

						Party PreviousTakenViaSupplier {set;}

						Party TakenViaSupplier {set;}

						PurchaseOrderObjectState CurrentObjectState {set;}

						ContactMechanism TakenViaContactMechanism {set;}

						ContactMechanism BillToContactMechanism {set;}

						Facility Facility {set;}

						PostalAddress ShipToAddress {set;}

						InternalOrganisation BillToPurchaser {set;}

		}
		public interface QuoteItemVersion  : Version 
		{
						global::System.String InternalComment {set;}

						Party Authorizer {set;}

						Deliverable Deliverable {set;}

						Product Product {set;}

						global::System.DateTime? EstimatedDeliveryDate {set;}

						global::System.DateTime? RequiredByDate {set;}

						UnitOfMeasure UnitOfMeasure {set;}

						ProductFeature ProductFeature {set;}

						global::System.Decimal? UnitPrice {set;}

						Skill Skill {set;}

						WorkEffort WorkEffort {set;}

						QuoteTerm QuoteTerms {set;}

						global::System.Int32? Quantity {set;}

						RequestItem RequestItem {set;}

						QuoteItemObjectState CurrentObjectState {set;}

		}
		public interface RequestForInformationVersion  : RequestVersion 
		{
		}
		public interface RequestForProposalVersion  : RequestVersion 
		{
		}
		public interface RequestForQuoteVersion  : RequestVersion 
		{
		}
		public interface RequestItemVersion  : Version 
		{
						global::System.String InternalComment {set;}

						global::System.String Description {set;}

						global::System.Int32? Quantity {set;}

						UnitOfMeasure UnitOfMeasure {set;}

						Requirement Requirements {set;}

						Deliverable Deliverable {set;}

						ProductFeature ProductFeature {set;}

						NeededSkill NeededSkill {set;}

						Product Product {set;}

						global::System.Decimal? MaximumAllowedPrice {set;}

						global::System.DateTime? RequiredByDate {set;}

						RequestItemObjectState CurrentObjectState {set;}

		}
		public interface ResearchVersion  : WorkEffortVersion 
		{
		}
		public interface SalesInvoiceItemVersion  : InvoiceItemVersion 
		{
						ProductFeature ProductFeature {set;}

						SalesInvoiceItemObjectState CurrentObjectState {set;}

						global::System.Decimal? RequiredProfitMargin {set;}

						global::System.Decimal InitialMarkupPercentage {set;}

						global::System.Decimal MaintainedMarkupPercentage {set;}

						Product Product {set;}

						global::System.Decimal UnitPurchasePrice {set;}

						SalesOrderItem SalesOrderItem {set;}

						SalesInvoiceItemType SalesInvoiceItemType {set;}

						Person SalesRep {set;}

						global::System.Decimal InitialProfitMargin {set;}

						global::System.Decimal MaintainedProfitMargin {set;}

						TimeEntry TimeEntries {set;}

						global::System.Decimal? RequiredMarkupPercentage {set;}

		}
		public interface SalesInvoiceVersion  : InvoiceVersion 
		{
						SalesInvoiceObjectState CurrentObjectState {set;}

						global::System.Decimal? TotalListPrice {set;}

						ContactMechanism BillToContactMechanism {set;}

						Party PreviousBillToCustomer {set;}

						SalesInvoiceType SalesInvoiceType {set;}

						global::System.Decimal InitialProfitMargin {set;}

						PaymentMethod PaymentMethod {set;}

						SalesOrder SalesOrder {set;}

						global::System.Decimal InitialMarkupPercentage {set;}

						global::System.Decimal MaintainedMarkupPercentage {set;}

						Person SalesReps {set;}

						Shipment Shipment {set;}

						global::System.Decimal MaintainedProfitMargin {set;}

						Party PreviousShipToCustomer {set;}

						Party BillToCustomer {set;}

						SalesInvoiceItem SalesInvoiceItems {set;}

						global::System.Decimal TotalListPriceCustomerCurrency {set;}

						Party ShipToCustomer {set;}

						ContactMechanism BilledFromContactMechanism {set;}

						global::System.Decimal? TotalPurchasePrice {set;}

						SalesChannel SalesChannel {set;}

						Party Customers {set;}

						PostalAddress ShipToAddress {set;}

						Store Store {set;}

		}
		public interface SalesOrderItemVersion  : OrderItemVersion 
		{
						global::System.Decimal InitialProfitMargin {set;}

						global::System.Decimal QuantityShortFalled {set;}

						OrderItem OrderedWithFeatures {set;}

						global::System.Decimal MaintainedProfitMargin {set;}

						global::System.Decimal? RequiredProfitMargin {set;}

						NonSerialisedInventoryItem PreviousReservedFromInventoryItem {set;}

						global::System.Decimal? QuantityShipNow {set;}

						global::System.Decimal? RequiredMarkupPercentage {set;}

						global::System.Decimal QuantityShipped {set;}

						PostalAddress ShipToAddress {set;}

						global::System.Decimal QuantityPicked {set;}

						Product PreviousProduct {set;}

						SalesOrderItemObjectState CurrentObjectState {set;}

						global::System.Decimal UnitPurchasePrice {set;}

						Party ShipToParty {set;}

						PostalAddress AssignedShipToAddress {set;}

						global::System.Decimal QuantityReturned {set;}

						global::System.Decimal QuantityReserved {set;}

						Person SalesRep {set;}

						Party AssignedShipToParty {set;}

						global::System.Decimal QuantityPendingShipment {set;}

						global::System.Decimal MaintainedMarkupPercentage {set;}

						global::System.Decimal InitialMarkupPercentage {set;}

						NonSerialisedInventoryItem ReservedFromInventoryItem {set;}

						Product Product {set;}

						ProductFeature ProductFeature {set;}

						global::System.Decimal QuantityRequestsShipping {set;}

		}
		public interface SalesOrderVersion  : OrderVersion 
		{
						ContactMechanism TakenByContactMechanism {set;}

						Party ShipToCustomer {set;}

						Party BillToCustomer {set;}

						global::System.Decimal TotalPurchasePrice {set;}

						ShipmentMethod ShipmentMethod {set;}

						global::System.Decimal TotalListPriceCustomerCurrency {set;}

						global::System.Decimal MaintainedProfitMargin {set;}

						PostalAddress ShipToAddress {set;}

						Party PreviousShipToCustomer {set;}

						ContactMechanism BillToContactMechanism {set;}

						Person SalesReps {set;}

						global::System.Decimal InitialProfitMargin {set;}

						global::System.Decimal TotalListPrice {set;}

						global::System.Boolean PartiallyShip {set;}

						Party Customers {set;}

						Store Store {set;}

						global::System.Decimal MaintainedMarkupPercentage {set;}

						ContactMechanism BillFromContactMechanism {set;}

						PaymentMethod PaymentMethod {set;}

						ContactMechanism PlacingContactMechanism {set;}

						Party PreviousBillToCustomer {set;}

						SalesChannel SalesChannel {set;}

						Party PlacingCustomer {set;}

						SalesInvoice ProformaInvoice {set;}

						SalesOrderItem SalesOrderItems {set;}

						SalesOrderObjectState CurrentObjectState {set;}

						global::System.Decimal InitialMarkupPercentage {set;}

						ProductQuote Quote {set;}

		}
		public interface SerialisedInventoryItemVersion  : InventoryItemVersion 
		{
						global::System.String SerialNumber {set;}

						Ownership Ownership {set;}

						global::System.String Owner {set;}

						global::System.Int32? AcquisitionYear {set;}

						global::System.Int32? ManufacturingYear {set;}

						global::System.Decimal? ReplacementValue {set;}

						global::System.Int32? LifeTime {set;}

						global::System.Int32? DepreciationYears {set;}

						global::System.Decimal? PurchasePrice {set;}

						global::System.Decimal? ExpectedSalesPrice {set;}

						global::System.Decimal? RefurbishCost {set;}

						global::System.Decimal? TransportCost {set;}

						SerialisedInventoryItemObjectState CurrentObjectState {set;}

		}
		public interface Note  : ExternalAccountingTransaction 
		{
		}
		public interface Obligation  : ExternalAccountingTransaction 
		{
		}
		public interface Office  : Facility 
		{
		}
		public interface OneTimeCharge  : PriceComponent 
		{
		}
		public interface OperatingBudget  : Budget 
		{
		}
		public interface OperatingCondition  : PartSpecification 
		{
		}
		public interface OrderItemBilling  : Object 
		{
						OrderItem OrderItem {set;}

						SalesInvoiceItem SalesInvoiceItem {set;}

						global::System.Decimal Amount {set;}

						global::System.Decimal? Quantity {set;}

		}
		public interface OrderKind  : UniquelyIdentifiable, AccessControlledObject 
		{
						global::System.String Description {set;}

						global::System.Boolean ScheduleManually {set;}

		}
		public interface OrderQuantityBreak  : AccessControlledObject 
		{
						global::System.Decimal? ThroughAmount {set;}

						global::System.Decimal? FromAmount {set;}

		}
		public interface OrderRequirementCommitment  : AccessControlledObject 
		{
						global::System.Int32 Quantity {set;}

						OrderItem OrderItem {set;}

						Requirement Requirement {set;}

		}
		public interface OrderShipment  : Deletable 
		{
						SalesOrderItem SalesOrderItem {set;}

						global::System.Boolean Picked {set;}

						ShipmentItem ShipmentItem {set;}

						global::System.Decimal Quantity {set;}

						PurchaseOrderItem PurchaseOrderItem {set;}

		}
		public interface OrderTerm  : AccessControlledObject 
		{
						global::System.String TermValue {set;}

						TermType TermType {set;}

		}
		public interface OrderValue  : AccessControlledObject 
		{
						global::System.Decimal? ThroughAmount {set;}

						global::System.Decimal? FromAmount {set;}

		}
		public interface Ordinal  : Enumeration 
		{
		}
		public interface Organisation  : Party, Deletable 
		{
						OrganisationRole OrganisationRoles {set;}

						SecurityToken ContactsSecurityToken {set;}

						AccessControl ContactsAccessControl {set;}

						UserGroup OwnerUserGroup {set;}

						LegalForm LegalForm {set;}

						global::System.String Name {set;}

						UserGroup ContactsUserGroup {set;}

						Media LogoImage {set;}

						global::System.String TaxNumber {set;}

						IndustryClassification IndustryClassifications {set;}

						OrganisationClassification OrganisationClassifications {set;}

		}
		public interface OrganisationContactKind  : AccessControlledObject, UniquelyIdentifiable 
		{
						global::System.String Description {set;}

		}
		public interface OrganisationContactRelationship  : PartyRelationship 
		{
						Person Contact {set;}

						Organisation Organisation {set;}

						OrganisationContactKind ContactKinds {set;}

		}
		public interface OrganisationGlAccount  : AccessControlledObject, Period 
		{
						Product Product {set;}

						OrganisationGlAccount Parent {set;}

						Party Party {set;}

						global::System.Boolean HasBankStatementTransactions {set;}

						ProductCategory ProductCategory {set;}

						GeneralLedgerAccount GeneralLedgerAccount {set;}

		}
		public interface OrganisationGlAccountBalance  : AccessControlledObject 
		{
						OrganisationGlAccount OrganisationGlAccount {set;}

						global::System.Decimal Amount {set;}

						AccountingPeriod AccountingPeriod {set;}

		}
		public interface OrganisationRole  : Enumeration 
		{
		}
		public interface OrganisationRollUp  : PartyRelationship 
		{
						Organisation Parent {set;}

						OrganisationUnit RollupKind {set;}

						Organisation Child {set;}

		}
		public interface OrganisationUnit  : Enumeration 
		{
		}
		public interface OwnBankAccount  : PaymentMethod, FinancialAccount 
		{
						BankAccount BankAccount {set;}

		}
		public interface OwnCreditCard  : PaymentMethod, FinancialAccount 
		{
						Person Owner {set;}

						CreditCard CreditCard {set;}

		}
		public interface Package  : UniquelyIdentifiable, AccessControlledObject 
		{
						global::System.String Name {set;}

		}
		public interface PackageQuantityBreak  : AccessControlledObject 
		{
						global::System.Int32? From {set;}

						global::System.Int32? Through {set;}

		}
		public interface PackageRevenue  : Deletable, AccessControlledObject 
		{
						global::System.Decimal Revenue {set;}

						global::System.Int32 Year {set;}

						global::System.Int32 Month {set;}

						Currency Currency {set;}

						global::System.String PackageName {set;}

						Package Package {set;}

		}
		public interface PackageRevenueHistory  : AccessControlledObject 
		{
						global::System.Decimal Revenue {set;}

						Package Package {set;}

						Currency Currency {set;}

		}
		public interface PackagingContent  : AccessControlledObject 
		{
						ShipmentItem ShipmentItem {set;}

						global::System.Decimal Quantity {set;}

		}
		public interface PackagingSlip  : Document 
		{
		}
		public interface PartBillOfMaterialSubstitute  : Period, AccessControlledObject, Commentable 
		{
						PartBillOfMaterial SubstitutionPartBillOfMaterial {set;}

						Ordinal Preference {set;}

						global::System.Int32? Quantity {set;}

						PartBillOfMaterial PartBillOfMaterial {set;}

		}
		public interface PartRevision  : Period, AccessControlledObject 
		{
						global::System.String Reason {set;}

						Part SupersededByPart {set;}

						Part Part {set;}

		}
		public interface PartSpecificationObjectState  : ObjectState 
		{
		}
		public interface PartSpecificationStatus  : AccessControlledObject 
		{
						global::System.DateTime StartDateTime {set;}

						PartSpecificationObjectState PartSpecificationObjectState {set;}

		}
		public interface PartSubstitute  : Commentable, AccessControlledObject 
		{
						Part SubstitutionPart {set;}

						Ordinal Preference {set;}

						global::System.DateTime? FromDate {set;}

						global::System.Int32 Quantity {set;}

						Part Part {set;}

		}
		public interface PartyBenefit  : AccessControlledObject 
		{
						TimeFrequency TimeFrequency {set;}

						global::System.Decimal? Cost {set;}

						global::System.Decimal? ActualEmployerPaidPercentage {set;}

						Benefit Benefit {set;}

						global::System.Decimal? ActualAvailableTime {set;}

		}
		public interface PartyContactMechanism  : Commentable, Auditable, Period, Deletable 
		{
						ContactMechanismPurpose ContactPurposes {set;}

						ContactMechanism ContactMechanism {set;}

						global::System.Boolean UseAsDefault {set;}

						global::System.Boolean? NonSolicitationIndicator {set;}

		}
		public interface PartyFixedAssetAssignment  : AccessControlledObject, Period, Commentable 
		{
						FixedAsset FixedAsset {set;}

						Party Party {set;}

						AssetAssignmentStatus AssetAssignmentStatus {set;}

						global::System.Decimal? AllocatedCost {set;}

		}
		public interface PartyPackageRevenue  : AccessControlledObject, Deletable 
		{
						global::System.Int32 Month {set;}

						Package Package {set;}

						Party Party {set;}

						global::System.Decimal Revenue {set;}

						global::System.Int32 Year {set;}

						global::System.String PartyPackageName {set;}

						Currency Currency {set;}

		}
		public interface PartyPackageRevenueHistory  : AccessControlledObject 
		{
						Package Package {set;}

						Currency Currency {set;}

						Party Party {set;}

						global::System.Decimal Revenue {set;}

		}
		public interface PartyProductCategoryRevenue  : AccessControlledObject, Deletable 
		{
						Party Party {set;}

						global::System.Decimal Revenue {set;}

						global::System.Int32 Month {set;}

						Currency Currency {set;}

						global::System.Int32 Year {set;}

						global::System.String PartyProductCategoryName {set;}

						ProductCategory ProductCategory {set;}

						global::System.Decimal Quantity {set;}

		}
		public interface PartyProductCategoryRevenueHistory  : AccessControlledObject 
		{
						ProductCategory ProductCategory {set;}

						Party Party {set;}

						global::System.Decimal Quantity {set;}

						global::System.Decimal Revenue {set;}

						Currency Currency {set;}

		}
		public interface PartyProductRevenue  : Deletable, AccessControlledObject 
		{
						global::System.Decimal Revenue {set;}

						global::System.Int32 Month {set;}

						global::System.Int32 Year {set;}

						global::System.String PartyProductName {set;}

						global::System.Decimal Quantity {set;}

						Currency Currency {set;}

						Party Party {set;}

						Product Product {set;}

		}
		public interface PartyProductRevenueHistory  : AccessControlledObject 
		{
						global::System.Decimal Revenue {set;}

						Party Party {set;}

						Product Product {set;}

						global::System.Decimal? Quantity {set;}

						Currency Currency {set;}

		}
		public interface PartyRevenue  : AccessControlledObject, Deletable 
		{
						Currency Currency {set;}

						global::System.Int32? Month {set;}

						Party Party {set;}

						global::System.Int32 Year {set;}

						global::System.Decimal Revenue {set;}

		}
		public interface PartyRevenueHistory  : AccessControlledObject 
		{
						Currency Currency {set;}

						global::System.Decimal Revenue {set;}

						Party Party {set;}

		}
		public interface PartySkill  : AccessControlledObject 
		{
						global::System.Decimal? YearsExperience {set;}

						global::System.DateTime? StartedUsingDate {set;}

						SkillRating SkillRating {set;}

						SkillLevel SkillLevel {set;}

						Skill Skill {set;}

		}
		public interface Passport  : AccessControlledObject 
		{
						global::System.DateTime? IssueDate {set;}

						global::System.DateTime? ExpiriationDate {set;}

						global::System.String Number {set;}

		}
		public interface PayCheck  : Payment 
		{
						Deduction Deductions {set;}

		}
		public interface PayGrade  : AccessControlledObject, Commentable 
		{
						global::System.String Name {set;}

						SalaryStep SalarySteps {set;}

		}
		public interface PayHistory  : AccessControlledObject, Period 
		{
						TimeFrequency TimeFrequency {set;}

						SalaryStep SalaryStep {set;}

						global::System.Decimal? Amount {set;}

		}
		public interface PaymentApplication  : AccessControlledObject 
		{
						global::System.Decimal AmountApplied {set;}

						InvoiceItem InvoiceItem {set;}

						Invoice Invoice {set;}

						BillingAccount BillingAccount {set;}

		}
		public interface PaymentBudgetAllocation  : AccessControlledObject 
		{
						Payment Payment {set;}

						BudgetItem BudgetItem {set;}

						global::System.Decimal Amount {set;}

		}
		public interface PayrollPreference  : AccessControlledObject 
		{
						global::System.Decimal? Percentage {set;}

						global::System.String AccountNumber {set;}

						PaymentMethod PaymentMethod {set;}

						TimeFrequency TimeFrequency {set;}

						DeductionType DeductionType {set;}

						global::System.Decimal? Amount {set;}

		}
		public interface PerformanceNote  : AccessControlledObject, Commentable 
		{
						global::System.String Description {set;}

						global::System.DateTime? CommunicationDate {set;}

						Person GivenByManager {set;}

						Person Employee {set;}

		}
		public interface PerformanceReview  : AccessControlledObject, Commentable, Period 
		{
						Person Manager {set;}

						PayHistory PayHistory {set;}

						PayCheck BonusPayCheck {set;}

						PerformanceReviewItem PerformanceReviewItems {set;}

						Person Employee {set;}

						Position ResultingPosition {set;}

		}
		public interface PerformanceReviewItem  : Commentable, AccessControlledObject 
		{
						RatingType RatingType {set;}

						PerformanceReviewItemType PerformanceReviewItemType {set;}

		}
		public interface PerformanceReviewItemType  : Enumeration 
		{
		}
		public interface PerformanceSpecification  : PartSpecification 
		{
		}
		public interface PersonalTitle  : Enumeration 
		{
		}
		public interface PersonRole  : Enumeration 
		{
		}
		public interface PersonTraining  : Period, AccessControlledObject 
		{
						Training Training {set;}

		}
		public interface Phase  : WorkEffort, Versioned 
		{
						PhaseVersion CurrentVersion {set;}

						PhaseVersion AllVersions {set;}

		}
		public interface PhoneCommunication  : CommunicationEvent, Versioned 
		{
						global::System.Boolean? LeftVoiceMail {set;}

						global::System.Boolean IncomingCall {set;}

						Party Receivers {set;}

						Party Callers {set;}

						PhoneCommunicationVersion CurrentVersion {set;}

						PhoneCommunicationVersion AllVersions {set;}

		}
		public interface PickList  : Printable, Transitional 
		{
						CustomerShipment CustomerShipmentCorrection {set;}

						global::System.DateTime CreationDate {set;}

						PickListItem PickListItems {set;}

						PickListObjectState CurrentObjectState {set;}

						PickListStatus CurrentPickListStatus {set;}

						Person Picker {set;}

						PickListStatus PickListStatuses {set;}

						Party ShipToParty {set;}

						Store Store {set;}

		}
		public interface PickListItem  : AccessControlledObject, Deletable 
		{
						global::System.Decimal RequestedQuantity {set;}

						InventoryItem InventoryItem {set;}

						global::System.Decimal? ActualQuantity {set;}

		}
		public interface PickListObjectState  : ObjectState 
		{
		}
		public interface PickListStatus  : AccessControlledObject 
		{
						PickListObjectState PickListObjectState {set;}

						global::System.DateTime StartDateTime {set;}

		}
		public interface Plant  : Facility 
		{
		}
		public interface Position  : AccessControlledObject 
		{
						Organisation Organisation {set;}

						global::System.Boolean? Temporary {set;}

						global::System.DateTime? EstimatedThroughDate {set;}

						global::System.DateTime? EstimatedFromDate {set;}

						PositionType PositionType {set;}

						global::System.Boolean? Fulltime {set;}

						global::System.Boolean? Salary {set;}

						PositionStatus PositionStatus {set;}

						BudgetItem ApprovedBudgetItem {set;}

						global::System.DateTime ActualFromDate {set;}

						global::System.DateTime? ActualThroughDate {set;}

		}
		public interface PositionFulfillment  : Commentable, Period, AccessControlledObject 
		{
						Position Position {set;}

						Person Person {set;}

		}
		public interface PositionReportingStructure  : AccessControlledObject, Commentable 
		{
						global::System.Boolean? Primary {set;}

						Position ManagedByPosition {set;}

						Position Position {set;}

		}
		public interface PositionResponsibility  : Commentable, AccessControlledObject 
		{
						Position Position {set;}

						Responsibility Responsibility {set;}

		}
		public interface PositionStatus  : Enumeration 
		{
		}
		public interface PositionType  : AccessControlledObject 
		{
						global::System.String Description {set;}

						Responsibility Responsibilities {set;}

						global::System.Decimal? BenefitPercentage {set;}

						global::System.String Title {set;}

						PositionTypeRate PositionTypeRate {set;}

		}
		public interface PositionTypeRate  : AccessControlledObject 
		{
						global::System.Decimal Rate {set;}

						RateType RateType {set;}

						TimeFrequency TimeFrequency {set;}

		}
		public interface PostalAddress  : ContactMechanism, GeoLocatable 
		{
						GeographicBoundary GeographicBoundaries {set;}

						global::System.String Address1 {set;}

						global::System.String Address2 {set;}

						global::System.String Address3 {set;}

						PostalBoundary PostalBoundary {set;}

						PostalCode PostalCode {set;}

						City City {set;}

						Country Country {set;}

						global::System.String Directions {set;}

		}
		public interface PostalBoundary  : AccessControlledObject, Deletable 
		{
						global::System.String PostalCode {set;}

						global::System.String Locality {set;}

						Country Country {set;}

						global::System.String Region {set;}

		}
		public interface PostalCode  : CountryBound, GeographicBoundary 
		{
						global::System.String Code {set;}

		}
		public interface PrintQueue  : AccessControlledObject, UniquelyIdentifiable 
		{
						Printable Printables {set;}

						global::System.String Name {set;}

		}
		public interface Priority  : Enumeration 
		{
		}
		public interface ProductCategory  : AccessControlledObject, UniquelyIdentifiable 
		{
						Package Package {set;}

						global::System.String Code {set;}

						Media NoImageAvailableImage {set;}

						ProductCategory Parents {set;}

						ProductCategory Children {set;}

						global::System.String Description {set;}

						global::System.String Name {set;}

						LocalisedText LocalisedNames {set;}

						LocalisedText LocalisedDescriptions {set;}

						Media CategoryImage {set;}

						ProductCategory Ancestors {set;}

						CatScope CatScope {set;}

		}
		public interface ProductCategoryRevenue  : Deletable, AccessControlledObject 
		{
						global::System.String ProductCategoryName {set;}

						global::System.Int32 Month {set;}

						ProductCategory ProductCategory {set;}

						global::System.Decimal Revenue {set;}

						Currency Currency {set;}

						global::System.Int32 Year {set;}

		}
		public interface ProductCategoryRevenueHistory  : AccessControlledObject 
		{
						Currency Currency {set;}

						global::System.Decimal Revenue {set;}

						ProductCategory ProductCategory {set;}

		}
		public interface ProductCharacteristic  : Enumeration 
		{
		}
		public interface ProductCharacteristicValue  : Deletable, Localised 
		{
						ProductCharacteristic ProductCharacteristic {set;}

						global::System.String Value {set;}

		}
		public interface ProductConfiguration  : ProductAssociation 
		{
						Product ProductsUsedIn {set;}

						Product Product {set;}

						global::System.Decimal? QuantityUsed {set;}

						global::System.String Description {set;}

		}
		public interface ProductDeliverySkillRequirement  : AccessControlledObject 
		{
						global::System.DateTime? StartedUsingDate {set;}

						Service Service {set;}

						Skill Skill {set;}

		}
		public interface ProductDrawing  : Document 
		{
		}
		public interface ProductFeatureApplicabilityRelationship  : AccessControlledObject 
		{
						Product AvailableFor {set;}

						ProductFeature UsedToDefine {set;}

		}
		public interface ProductionRun  : WorkEffort, Versioned 
		{
						global::System.Int32? QuantityProduced {set;}

						global::System.Int32? QuantityRejected {set;}

						global::System.Int32? QuantityToProduce {set;}

						ProductionRunVersion CurrentVersion {set;}

						ProductionRunVersion AllVersions {set;}

		}
		public interface ProductModel  : Document 
		{
		}
		public interface ProductPurchasePrice  : AccessControlledObject, Period 
		{
						global::System.Decimal Price {set;}

						UnitOfMeasure UnitOfMeasure {set;}

						Currency Currency {set;}

		}
		public interface ProductQuality  : ProductFeature, Enumeration 
		{
		}
		public interface ProductQuote  : Quote, Versioned 
		{
						ProductQuoteVersion CurrentVersion {set;}

						ProductQuoteVersion AllVersions {set;}

		}
		public interface ProductRequirement  : Requirement 
		{
						Product Product {set;}

						DesiredProductFeature DesiredProductFeatures {set;}

		}
		public interface ProductRevenue  : Deletable, AccessControlledObject 
		{
						global::System.Decimal Revenue {set;}

						global::System.String ProductName {set;}

						Currency Currency {set;}

						global::System.Int32 Year {set;}

						Product Product {set;}

						global::System.Int32 Month {set;}

		}
		public interface ProductRevenueHistory  : AccessControlledObject 
		{
						global::System.Decimal Revenue {set;}

						Currency Currency {set;}

						Product Product {set;}

		}
		public interface ProductType  : UniquelyIdentifiable, AccessControlledObject 
		{
						ProductCharacteristic ProductCharacteristics {set;}

						global::System.String Name {set;}

		}
		public interface ProfessionalAssignment  : AccessControlledObject, Period 
		{
						Person Professional {set;}

						EngagementItem EngagementItem {set;}

		}
		public interface ProfessionalPlacement  : EngagementItem 
		{
		}
		public interface ProfessionalServicesRelationship  : PartyRelationship 
		{
						Person Professional {set;}

						Organisation ProfessionalServicesProvider {set;}

		}
		public interface Program  : WorkEffort, Versioned 
		{
						ProgramVersion CurrentVersion {set;}

						ProgramVersion AllVersions {set;}

		}
		public interface Project  : WorkEffort, Versioned 
		{
						ProjectVersion CurrentVersion {set;}

						ProjectVersion AllVersions {set;}

		}
		public interface ProjectRequirement  : Requirement 
		{
						Deliverable NeededDeliverables {set;}

		}
		public interface Property  : FixedAsset 
		{
		}
		public interface Proposal  : Quote, Versioned 
		{
						ProposalVersion CurrentVersion {set;}

						ProposalVersion AllVersions {set;}

		}
		public interface Province  : CityBound, GeographicBoundary, CountryBound 
		{
						global::System.String Name {set;}

		}
		public interface PurchaseAgreement  : Agreement 
		{
		}
		public interface PurchaseInvoice  : Invoice, Versioned 
		{
						PurchaseInvoiceItem PurchaseInvoiceItems {set;}

						PurchaseInvoiceObjectState CurrentObjectState {set;}

						Party BilledFromParty {set;}

						PurchaseInvoiceType PurchaseInvoiceType {set;}

						PurchaseInvoiceVersion CurrentVersion {set;}

						PurchaseInvoiceVersion AllVersions {set;}

		}
		public interface PurchaseInvoiceItem  : InvoiceItem, Versioned 
		{
						PurchaseInvoiceItemType PurchaseInvoiceItemType {set;}

						Part Part {set;}

						PurchaseInvoiceItemObjectState CurrentObjectState {set;}

						PurchaseInvoiceItemVersion CurrentVersion {set;}

						PurchaseInvoiceItemVersion AllVersions {set;}

		}
		public interface PurchaseInvoiceItemObjectState  : ObjectState 
		{
		}
		public interface PurchaseInvoiceItemStatus  : AccessControlledObject 
		{
						PurchaseInvoiceItemObjectState PurchaseInvoiceItemObjectState {set;}

						global::System.DateTime StartDateTime {set;}

		}
		public interface PurchaseInvoiceItemType  : Enumeration 
		{
		}
		public interface PurchaseInvoiceObjectState  : ObjectState 
		{
		}
		public interface PurchaseInvoiceStatus  : AccessControlledObject 
		{
						global::System.DateTime? StartDateTime {set;}

						PurchaseInvoiceObjectState PurchaseInvoiceObjectState {set;}

		}
		public interface PurchaseInvoiceType  : Enumeration 
		{
		}
		public interface PurchaseOrder  : Order, Versioned 
		{
						PurchaseOrderItem PurchaseOrderItems {set;}

						Party PreviousTakenViaSupplier {set;}

						Party TakenViaSupplier {set;}

						PurchaseOrderObjectState CurrentObjectState {set;}

						ContactMechanism TakenViaContactMechanism {set;}

						ContactMechanism BillToContactMechanism {set;}

						Facility Facility {set;}

						PostalAddress ShipToAddress {set;}

						PurchaseOrderVersion CurrentVersion {set;}

						PurchaseOrderVersion AllVersions {set;}

		}
		public interface PurchaseOrderItem  : OrderItem, Versioned 
		{
						PurchaseOrderItemObjectState CurrentObjectState {set;}

						global::System.Decimal QuantityReceived {set;}

						Product Product {set;}

						Part Part {set;}

						PurchaseOrderItemVersion CurrentVersion {set;}

						PurchaseOrderItemVersion AllVersions {set;}

		}
		public interface PurchaseOrderItemObjectState  : ObjectState 
		{
		}
		public interface PurchaseOrderItemStatus  : AccessControlledObject 
		{
						global::System.DateTime StartDateTime {set;}

						PurchaseOrderItemObjectState PurchaseOrderItemObjectState {set;}

		}
		public interface PurchaseOrderObjectState  : ObjectState 
		{
		}
		public interface PurchaseOrderStatus  : AccessControlledObject 
		{
						PurchaseOrderObjectState PurchaseOrderObjectState {set;}

						global::System.DateTime StartDateTime {set;}

		}
		public interface PurchaseReturn  : Shipment 
		{
						PurchaseReturnStatus CurrentShipmentStatus {set;}

						PurchaseReturnObjectState CurrentObjectState {set;}

						PurchaseReturnStatus ShipmentStatuses {set;}

		}
		public interface PurchaseReturnObjectState  : ObjectState 
		{
		}
		public interface PurchaseReturnStatus  : AccessControlledObject 
		{
						PurchaseReturnObjectState PurchaseReturnObjectState {set;}

						global::System.DateTime StartDateTime {set;}

		}
		public interface PurchaseShipment  : Shipment 
		{
						PurchaseShipmentObjectState CurrentObjectState {set;}

						Facility Facility {set;}

						PurchaseShipmentStatus ShipmentStatuses {set;}

						PurchaseShipmentStatus CurrentShipmentStatus {set;}

						PurchaseOrder PurchaseOrder {set;}

		}
		public interface PurchaseShipmentObjectState  : ObjectState 
		{
		}
		public interface PurchaseShipmentStatus  : AccessControlledObject 
		{
						PurchaseShipmentObjectState PurchaseShipmentObjectState {set;}

						global::System.DateTime StartDateTime {set;}

		}
		public interface Qualification  : Enumeration 
		{
		}
		public interface QuoteItem  : Commentable, Transitional, Versioned 
		{
						global::System.String InternalComment {set;}

						Party Authorizer {set;}

						Deliverable Deliverable {set;}

						Product Product {set;}

						global::System.DateTime? EstimatedDeliveryDate {set;}

						global::System.DateTime? RequiredByDate {set;}

						UnitOfMeasure UnitOfMeasure {set;}

						ProductFeature ProductFeature {set;}

						global::System.Decimal? UnitPrice {set;}

						Skill Skill {set;}

						WorkEffort WorkEffort {set;}

						QuoteTerm QuoteTerms {set;}

						global::System.Int32? Quantity {set;}

						RequestItem RequestItem {set;}

						QuoteItemObjectState CurrentObjectState {set;}

						QuoteItemVersion CurrentVersion {set;}

						QuoteItemVersion AllVersions {set;}

		}
		public interface QuoteTerm  : AccessControlledObject 
		{
						global::System.String TermValue {set;}

						TermType TermType {set;}

		}
		public interface RateType  : Enumeration 
		{
		}
		public interface RatingType  : Enumeration 
		{
		}
		public interface RawMaterial  : Part 
		{
		}
		public interface Receipt  : Payment 
		{
		}
		public interface ReceiptAccountingTransaction  : ExternalAccountingTransaction 
		{
						Receipt Receipt {set;}

		}
		public interface RecurringCharge  : PriceComponent 
		{
						TimeFrequency TimeFrequency {set;}

		}
		public interface Region  : GeographicBoundaryComposite 
		{
						global::System.String Name {set;}

		}
		public interface RequestForInformation  : Request, Versioned 
		{
						RequestForInformationVersion CurrentVersion {set;}

						RequestForInformationVersion AllVersions {set;}

		}
		public interface RequestForProposal  : Request, Versioned 
		{
						RequestForProposalVersion CurrentVersion {set;}

						RequestForProposalVersion AllVersions {set;}

		}
		public interface RequestForQuote  : Request, Versioned 
		{
						RequestForQuoteVersion CurrentVersion {set;}

						RequestForQuoteVersion AllVersions {set;}

		}
		public interface RequestItem  : Commentable, Transitional, Versioned 
		{
						global::System.String InternalComment {set;}

						global::System.String Description {set;}

						global::System.Int32? Quantity {set;}

						UnitOfMeasure UnitOfMeasure {set;}

						Requirement Requirements {set;}

						Deliverable Deliverable {set;}

						ProductFeature ProductFeature {set;}

						NeededSkill NeededSkill {set;}

						Product Product {set;}

						global::System.Decimal? MaximumAllowedPrice {set;}

						global::System.DateTime? RequiredByDate {set;}

						RequestItemObjectState CurrentObjectState {set;}

						RequestItemVersion CurrentVersion {set;}

						RequestItemVersion AllVersions {set;}

		}
		public interface QuoteObjectState  : ObjectState 
		{
		}
		public interface QuoteStatus  : AccessControlledObject 
		{
						global::System.DateTime StartDateTime {set;}

						QuoteObjectState QuoteObjectState {set;}

		}
		public interface QuoteItemObjectState  : ObjectState 
		{
		}
		public interface QuoteItemStatus  : AccessControlledObject 
		{
						QuoteItemObjectState QuoteItemObjectState {set;}

						global::System.DateTime StartDateTime {set;}

		}
		public interface RequirementBudgetAllocation  : AccessControlledObject 
		{
						BudgetItem BudgetItem {set;}

						Requirement Requirement {set;}

						global::System.Decimal Amount {set;}

		}
		public interface RequirementCommunication  : AccessControlledObject 
		{
						CommunicationEvent CommunicationEvent {set;}

						Requirement Requirement {set;}

						Person AssociatedProfessional {set;}

		}
		public interface RequirementObjectState  : ObjectState 
		{
		}
		public interface RequirementStatus  : AccessControlledObject 
		{
						RequirementObjectState RequirementObjectState {set;}

						global::System.DateTime StartDateTime {set;}

		}
		public interface Research  : WorkEffort, Versioned 
		{
						ResearchVersion CurrentVersion {set;}

						ResearchVersion AllVersions {set;}

		}
		public interface ResourceRequirement  : Requirement 
		{
						global::System.String Duties {set;}

						global::System.Decimal? NumberOfPositions {set;}

						global::System.DateTime? RequiredStartDate {set;}

						NeededSkill NeededSkills {set;}

						global::System.DateTime? RequiredEndDate {set;}

		}
		public interface RespondingParty  : AccessControlledObject 
		{
						global::System.DateTime? SendingDate {set;}

						ContactMechanism ContactMechanism {set;}

						Party Party {set;}

		}
		public interface Responsibility  : AccessControlledObject 
		{
						global::System.String Description {set;}

		}
		public interface Resume  : AccessControlledObject 
		{
						global::System.DateTime ResumeDate {set;}

						global::System.String ResumeText {set;}

		}
		public interface RevenueQuantityBreak  : AccessControlledObject 
		{
						ProductCategory ProductCategory {set;}

						global::System.Decimal? Through {set;}

						global::System.Decimal? From {set;}

		}
		public interface RevenueValueBreak  : AccessControlledObject 
		{
						ProductCategory ProductCategory {set;}

						global::System.Decimal? ThroughAmount {set;}

						global::System.Decimal? FromAmount {set;}

		}
		public interface Room  : Facility, Container 
		{
		}
		public interface SalaryStep  : AccessControlledObject 
		{
						global::System.DateTime ModifiedDate {set;}

						global::System.Decimal Amount {set;}

		}
		public interface SalesAccountingTransaction  : ExternalAccountingTransaction 
		{
						Invoice Invoice {set;}

		}
		public interface SalesAgreement  : Agreement 
		{
		}
		public interface SalesChannel  : Enumeration 
		{
		}
		public interface SalesChannelRevenue  : AccessControlledObject, Deletable 
		{
						global::System.Int32 Year {set;}

						global::System.Int32 Month {set;}

						Currency Currency {set;}

						SalesChannel SalesChannel {set;}

						global::System.String SalesChannelName {set;}

						global::System.Decimal Revenue {set;}

		}
		public interface SalesChannelRevenueHistory  : AccessControlledObject 
		{
						SalesChannel SalesChannel {set;}

						Currency Currency {set;}

						global::System.Decimal Revenue {set;}

		}
		public interface SalesInvoice  : Invoice, Versioned 
		{
						SalesInvoiceObjectState CurrentObjectState {set;}

						global::System.Decimal? TotalListPrice {set;}

						ContactMechanism BillToContactMechanism {set;}

						Party PreviousBillToCustomer {set;}

						SalesInvoiceType SalesInvoiceType {set;}

						global::System.Decimal InitialProfitMargin {set;}

						PaymentMethod PaymentMethod {set;}

						SalesOrder SalesOrder {set;}

						global::System.Decimal InitialMarkupPercentage {set;}

						global::System.Decimal MaintainedMarkupPercentage {set;}

						Person SalesReps {set;}

						Shipment Shipment {set;}

						global::System.Decimal MaintainedProfitMargin {set;}

						Party PreviousShipToCustomer {set;}

						Party BillToCustomer {set;}

						SalesInvoiceItem SalesInvoiceItems {set;}

						global::System.Decimal TotalListPriceCustomerCurrency {set;}

						Party ShipToCustomer {set;}

						ContactMechanism BilledFromContactMechanism {set;}

						global::System.Decimal? TotalPurchasePrice {set;}

						SalesChannel SalesChannel {set;}

						Party Customers {set;}

						PostalAddress ShipToAddress {set;}

						Store Store {set;}

						SalesInvoiceVersion CurrentVersion {set;}

						SalesInvoiceVersion AllVersions {set;}

		}
		public interface SalesInvoiceItem  : InvoiceItem, Versioned 
		{
						ProductFeature ProductFeature {set;}

						SalesInvoiceItemObjectState CurrentObjectState {set;}

						global::System.Decimal? RequiredProfitMargin {set;}

						global::System.Decimal InitialMarkupPercentage {set;}

						global::System.Decimal MaintainedMarkupPercentage {set;}

						Product Product {set;}

						global::System.Decimal UnitPurchasePrice {set;}

						SalesOrderItem SalesOrderItem {set;}

						SalesInvoiceItemType SalesInvoiceItemType {set;}

						Person SalesRep {set;}

						global::System.Decimal InitialProfitMargin {set;}

						global::System.Decimal MaintainedProfitMargin {set;}

						TimeEntry TimeEntries {set;}

						global::System.Decimal? RequiredMarkupPercentage {set;}

						SalesInvoiceItemVersion CurrentVersion {set;}

						SalesInvoiceItemVersion AllVersions {set;}

		}
		public interface SalesInvoiceItemObjectState  : ObjectState 
		{
		}
		public interface SalesInvoiceItemStatus  : AccessControlledObject 
		{
						global::System.DateTime StartDateTime {set;}

						SalesInvoiceItemObjectState SalesInvoiceItemObjectState {set;}

		}
		public interface SalesInvoiceItemType  : Enumeration 
		{
		}
		public interface SalesInvoiceObjectState  : ObjectState 
		{
		}
		public interface SalesInvoiceStatus  : AccessControlledObject 
		{
						SalesInvoiceObjectState SalesInvoiceObjectState {set;}

						global::System.DateTime StartDateTime {set;}

		}
		public interface SalesInvoiceType  : Enumeration 
		{
		}
		public interface SalesOrder  : Order, Versioned 
		{
						ContactMechanism TakenByContactMechanism {set;}

						Party ShipToCustomer {set;}

						Party BillToCustomer {set;}

						global::System.Decimal TotalPurchasePrice {set;}

						ShipmentMethod ShipmentMethod {set;}

						global::System.Decimal TotalListPriceCustomerCurrency {set;}

						global::System.Decimal MaintainedProfitMargin {set;}

						PostalAddress ShipToAddress {set;}

						Party PreviousShipToCustomer {set;}

						ContactMechanism BillToContactMechanism {set;}

						Person SalesReps {set;}

						global::System.Decimal InitialProfitMargin {set;}

						global::System.Decimal TotalListPrice {set;}

						global::System.Boolean PartiallyShip {set;}

						Party Customers {set;}

						Store Store {set;}

						global::System.Decimal MaintainedMarkupPercentage {set;}

						ContactMechanism BillFromContactMechanism {set;}

						PaymentMethod PaymentMethod {set;}

						ContactMechanism PlacingContactMechanism {set;}

						Party PreviousBillToCustomer {set;}

						SalesChannel SalesChannel {set;}

						Party PlacingCustomer {set;}

						SalesInvoice ProformaInvoice {set;}

						SalesOrderItem SalesOrderItems {set;}

						SalesOrderObjectState CurrentObjectState {set;}

						global::System.Decimal InitialMarkupPercentage {set;}

						ProductQuote Quote {set;}

						SalesOrderVersion CurrentVersion {set;}

						SalesOrderVersion AllVersions {set;}

		}
		public interface SalesOrderItem  : OrderItem, Versioned 
		{
						global::System.Decimal InitialProfitMargin {set;}

						global::System.Decimal QuantityShortFalled {set;}

						OrderItem OrderedWithFeatures {set;}

						global::System.Decimal MaintainedProfitMargin {set;}

						global::System.Decimal? RequiredProfitMargin {set;}

						NonSerialisedInventoryItem PreviousReservedFromInventoryItem {set;}

						global::System.Decimal? QuantityShipNow {set;}

						global::System.Decimal? RequiredMarkupPercentage {set;}

						global::System.Decimal QuantityShipped {set;}

						PostalAddress ShipToAddress {set;}

						global::System.Decimal QuantityPicked {set;}

						Product PreviousProduct {set;}

						SalesOrderItemObjectState CurrentObjectState {set;}

						global::System.Decimal UnitPurchasePrice {set;}

						Party ShipToParty {set;}

						PostalAddress AssignedShipToAddress {set;}

						global::System.Decimal QuantityReturned {set;}

						global::System.Decimal QuantityReserved {set;}

						Person SalesRep {set;}

						Party AssignedShipToParty {set;}

						global::System.Decimal QuantityPendingShipment {set;}

						global::System.Decimal MaintainedMarkupPercentage {set;}

						global::System.Decimal InitialMarkupPercentage {set;}

						NonSerialisedInventoryItem ReservedFromInventoryItem {set;}

						Product Product {set;}

						ProductFeature ProductFeature {set;}

						global::System.Decimal QuantityRequestsShipping {set;}

						SalesOrderItemVersion CurrentVersion {set;}

						SalesOrderItemVersion AllVersions {set;}

		}
		public interface RequestItemObjectState  : ObjectState 
		{
		}
		public interface SalesOrderItemObjectState  : ObjectState 
		{
		}
		public interface RequestItemStatus  : AccessControlledObject 
		{
						RequestItemObjectState RequestItemObjectState {set;}

						global::System.DateTime StartDateTime {set;}

		}
		public interface SalesOrderItemStatus  : AccessControlledObject 
		{
						SalesOrderItemObjectState SalesOrderItemObjectState {set;}

						global::System.DateTime StartDateTime {set;}

		}
		public interface RequestObjectState  : ObjectState 
		{
		}
		public interface SalesOrderObjectState  : ObjectState 
		{
		}
		public interface RequestStatus  : AccessControlledObject 
		{
						global::System.DateTime StartDateTime {set;}

						RequestObjectState RequestObjectState {set;}

		}
		public interface SalesOrderStatus  : AccessControlledObject 
		{
						global::System.DateTime StartDateTime {set;}

						SalesOrderObjectState SalesOrderObjectState {set;}

		}
		public interface SalesRepCommission  : AccessControlledObject 
		{
						global::System.Decimal? Commission {set;}

						global::System.String SalesRepName {set;}

						global::System.Int32? Month {set;}

						global::System.Int32 Year {set;}

						Currency Currency {set;}

						Person SalesRep {set;}

		}
		public interface SalesRepPartyProductCategoryRevenue  : AccessControlledObject, Deletable 
		{
						global::System.Int32 Year {set;}

						Person SalesRep {set;}

						ProductCategory ProductCategory {set;}

						global::System.Int32 Month {set;}

						Party Party {set;}

						global::System.Decimal Revenue {set;}

						Currency Currency {set;}

						global::System.String SalesRepName {set;}

		}
		public interface SalesRepPartyRevenue  : AccessControlledObject, Deletable 
		{
						global::System.Decimal Revenue {set;}

						global::System.Int32 Year {set;}

						Person SalesRep {set;}

						global::System.String SalesRepName {set;}

						Party Party {set;}

						Currency Currency {set;}

						global::System.Int32 Month {set;}

		}
		public interface SalesRepProductCategoryRevenue  : AccessControlledObject, Deletable 
		{
						global::System.Int32 Month {set;}

						global::System.String SalesRepName {set;}

						ProductCategory ProductCategory {set;}

						Currency Currency {set;}

						global::System.Decimal Revenue {set;}

						global::System.Int32 Year {set;}

						Person SalesRep {set;}

		}
		public interface SalesRepRelationship  : Commentable, PartyRelationship 
		{
						Person SalesRepresentative {set;}

						global::System.Decimal LastYearsCommission {set;}

						ProductCategory ProductCategories {set;}

						global::System.Decimal YTDCommission {set;}

						Party Customer {set;}

		}
		public interface SalesRepRevenue  : AccessControlledObject, Deletable 
		{
						global::System.Decimal Revenue {set;}

						Currency Currency {set;}

						global::System.Int32 Month {set;}

						global::System.String SalesRepName {set;}

						global::System.Int32 Year {set;}

						Person SalesRep {set;}

		}
		public interface SalesRepRevenueHistory  : AccessControlledObject 
		{
						Currency Currency {set;}

						Person SalesRep {set;}

						global::System.Decimal Revenue {set;}

		}
		public interface SalesTerritory  : GeographicBoundaryComposite 
		{
						global::System.String Name {set;}

		}
		public interface Salutation  : Enumeration 
		{
		}
		public interface SerialisedInventoryItem  : InventoryItem, Versioned 
		{
						global::System.String SerialNumber {set;}

						Ownership Ownership {set;}

						global::System.String Owner {set;}

						global::System.Int32? AcquisitionYear {set;}

						global::System.Int32? ManufacturingYear {set;}

						global::System.Decimal? ReplacementValue {set;}

						global::System.Int32? LifeTime {set;}

						global::System.Int32? DepreciationYears {set;}

						global::System.Decimal? PurchasePrice {set;}

						global::System.Decimal? ExpectedSalesPrice {set;}

						global::System.Decimal? RefurbishCost {set;}

						global::System.Decimal? TransportCost {set;}

						SerialisedInventoryItemObjectState CurrentObjectState {set;}

						SerialisedInventoryItemVersion CurrentVersion {set;}

						SerialisedInventoryItemVersion AllVersions {set;}

		}
		public interface SerialisedInventoryItemObjectState  : ObjectState 
		{
		}
		public interface SerializedInventoryItemObjectState  : ObjectState 
		{
		}
		public interface SerializedInventoryItemStatus  : AccessControlledObject 
		{
						global::System.DateTime StartDateTime {set;}

						SerializedInventoryItemObjectState SerializedInventoryItemObjectState {set;}

		}
		public interface ServiceConfiguration  : InventoryItemConfiguration 
		{
		}
		public interface ServiceEntryBilling  : Object 
		{
						ServiceEntry ServiceEntry {set;}

						InvoiceItem InvoiceItem {set;}

		}
		public interface ServiceEntryHeader  : Period, AccessControlledObject 
		{
						ServiceEntry ServiceEntries {set;}

						global::System.DateTime SubmittedDate {set;}

						Person SubmittedBy {set;}

		}
		public interface ServiceFeature  : Enumeration, ProductFeature 
		{
		}
		public interface ServiceTerritory  : GeographicBoundaryComposite 
		{
						global::System.String Name {set;}

		}
		public interface Shelf  : Container 
		{
		}
		public interface ShipmentItem  : Deletable, AccessControlledObject 
		{
						global::System.Decimal Quantity {set;}

						Part Part {set;}

						global::System.String ContentsDescription {set;}

						Document Documents {set;}

						global::System.Decimal QuantityShipped {set;}

						ShipmentItem InResponseToShipmentItems {set;}

						InventoryItem InventoryItems {set;}

						ProductFeature ProductFeatures {set;}

						InvoiceItem InvoiceItems {set;}

						Good Good {set;}

		}
		public interface ShipmentMethod  : Enumeration 
		{
		}
		public interface ShipmentPackage  : AccessControlledObject, UniquelyIdentifiable 
		{
						PackagingContent PackagingContents {set;}

						Document Documents {set;}

						global::System.DateTime CreationDate {set;}

						global::System.Int32 SequenceNumber {set;}

		}
		public interface ShipmentReceipt  : AccessControlledObject 
		{
						global::System.String ItemDescription {set;}

						NonSerialisedInventoryItem InventoryItem {set;}

						global::System.String RejectionReason {set;}

						OrderItem OrderItem {set;}

						global::System.Decimal QuantityRejected {set;}

						ShipmentItem ShipmentItem {set;}

						global::System.DateTime ReceivedDateTime {set;}

						global::System.Decimal QuantityAccepted {set;}

		}
		public interface ShipmentRouteSegment  : AccessControlledObject 
		{
						global::System.Decimal? EndKilometers {set;}

						Facility FromFacility {set;}

						global::System.Decimal? StartKilometers {set;}

						ShipmentMethod ShipmentMethod {set;}

						global::System.DateTime? EstimatedStartDateTime {set;}

						Facility ToFacility {set;}

						global::System.DateTime? EstimatedArrivalDateTime {set;}

						Vehicle Vehicle {set;}

						global::System.DateTime? ActualArrivalDateTime {set;}

						global::System.DateTime? ActualStartDateTime {set;}

						Organisation Carrier {set;}

		}
		public interface ShipmentValue  : AccessControlledObject 
		{
						global::System.Decimal? ThroughAmount {set;}

						global::System.Decimal? FromAmount {set;}

		}
		public interface ShippingAndHandlingCharge  : OrderAdjustment 
		{
		}
		public interface ShippingAndHandlingComponent  : AccessControlledObject, Period 
		{
						global::System.Decimal? Cost {set;}

						ShipmentMethod ShipmentMethod {set;}

						Carrier Carrier {set;}

						ShipmentValue ShipmentValue {set;}

						Currency Currency {set;}

						GeographicBoundary GeographicBoundary {set;}

		}
		public interface Size  : Enumeration, ProductFeature 
		{
		}
		public interface Skill  : Enumeration 
		{
		}
		public interface SkillLevel  : Enumeration 
		{
		}
		public interface SkillRating  : Enumeration 
		{
		}
		public interface SoftwareFeature  : ProductFeature, Enumeration 
		{
		}
		public interface StandardServiceOrderItem  : EngagementItem 
		{
		}
		public interface State  : CityBound, GeographicBoundary, CountryBound 
		{
						global::System.String Name {set;}

		}
		public interface StatementOfWork  : Quote, Versioned 
		{
						StatementOfWorkVersion CurrentVersion {set;}

						StatementOfWorkVersion AllVersions {set;}

		}
		public interface StatementOfWorkVersion  : QuoteVersion 
		{
		}
		public interface Store  : UniquelyIdentifiable, AccessControlledObject 
		{
						Catalogue Catalogues {set;}

						global::System.Decimal ShipmentThreshold {set;}

						Counter SalesOrderCounter {set;}

						global::System.String OutgoingShipmentNumberPrefix {set;}

						global::System.String SalesInvoiceNumberPrefix {set;}

						global::System.Int32 PaymentGracePeriod {set;}

						Media LogoImage {set;}

						global::System.Int32 PaymentNetDays {set;}

						Facility DefaultFacility {set;}

						global::System.String Name {set;}

						global::System.Decimal CreditLimit {set;}

						ShipmentMethod DefaultShipmentMethod {set;}

						Carrier DefaultCarrier {set;}

						Counter SalesInvoiceCounter {set;}

						global::System.Decimal OrderThreshold {set;}

						PaymentMethod DefaultPaymentMethod {set;}

						FiscalYearInvoiceNumber FiscalYearInvoiceNumbers {set;}

						PaymentMethod PaymentMethods {set;}

						Counter OutgoingShipmentCounter {set;}

						global::System.String SalesOrderNumberPrefix {set;}

						ProcessFlow ProcessFlow {set;}

		}
		public interface StoreRevenue  : AccessControlledObject, Deletable 
		{
						global::System.Int32 Month {set;}

						Currency Currency {set;}

						Store Store {set;}

						global::System.String StoreName {set;}

						global::System.Decimal Revenue {set;}

						global::System.Int32 Year {set;}

		}
		public interface StoreRevenueHistory  : AccessControlledObject 
		{
						Currency Currency {set;}

						Store Store {set;}

						global::System.Decimal Revenue {set;}

		}
		public interface StringTemplate  : UniquelyIdentifiable, Localised 
		{
						global::System.String Body {set;}

						global::System.String Name {set;}

		}
		public interface SubAgreement  : AgreementItem 
		{
		}
		public interface SubAssembly  : Part 
		{
		}
		public interface SubContractorAgreement  : Agreement 
		{
		}
		public interface SubContractorRelationship  : PartyRelationship 
		{
						Party Contractor {set;}

						Party SubContractor {set;}

		}
		public interface SupplierOffering  : Commentable, Period, AccessControlledObject 
		{
						RatingType Rating {set;}

						global::System.Int32? StandardLeadTime {set;}

						ProductPurchasePrice ProductPurchasePrices {set;}

						Ordinal Preference {set;}

						global::System.Decimal? MinimalOrderQuantity {set;}

						Product Product {set;}

						Party Supplier {set;}

						global::System.String ReferenceNumber {set;}

						Part Part {set;}

		}
		public interface SurchargeAdjustment  : OrderAdjustment 
		{
		}
		public interface SurchargeComponent  : PriceComponent 
		{
						global::System.Decimal? Percentage {set;}

		}
		public interface WebSiteCommunicationVersion  : CommunicationEventVersion 
		{
						Party Originator {set;}

						Party Receiver {set;}

		}
		public interface WorkFlowVersion  : WorkEffortVersion 
		{
		}
		public interface WorkTask  : WorkEffort, Versioned 
		{
						global::System.Boolean? SendNotification {set;}

						global::System.Boolean? SendReminder {set;}

						global::System.DateTime? RemindAt {set;}

						WorkTaskVersion CurrentVersion {set;}

						WorkTaskVersion AllVersions {set;}

		}
		public interface TaxDocument  : Document 
		{
		}
		public interface TaxDue  : ExternalAccountingTransaction 
		{
		}
		public interface TelecommunicationsNumber  : ContactMechanism 
		{
						global::System.String CountryCode {set;}

						global::System.String AreaCode {set;}

						global::System.String ContactNumber {set;}

		}
		public interface TermType  : Enumeration 
		{
		}
		public interface Territory  : CityBound, GeographicBoundary, CountryBound 
		{
						global::System.String Name {set;}

		}
		public interface TestingRequirement  : PartSpecification 
		{
		}
		public interface Threshold  : AgreementTerm 
		{
		}
		public interface TimeAndMaterialsService  : Service 
		{
		}
		public interface TimeEntry  : ServiceEntry 
		{
						global::System.Decimal Cost {set;}

						global::System.Decimal GrossMargin {set;}

						QuoteTerm QuoteTerm {set;}

						global::System.Decimal? BillingRate {set;}

						UnitOfMeasure UnitOfMeasure {set;}

						global::System.Decimal? AmountOfTime {set;}

		}
		public interface TimeFrequency  : Enumeration, IUnitOfMeasure 
		{
		}
		public interface TimePeriodUsage  : DeploymentUsage 
		{
		}
		public interface Tolerance  : PartSpecification 
		{
		}
		public interface Training  : AccessControlledObject 
		{
						global::System.String Description {set;}

		}
		public interface Transfer  : Shipment 
		{
						TransferObjectState CurrentObjectState {set;}

						TransferStatus CurrentShipmentStatus {set;}

						TransferStatus ShipmentStatuses {set;}

		}
		public interface TransferObjectState  : ObjectState 
		{
		}
		public interface TransferStatus  : AccessControlledObject 
		{
						global::System.DateTime StartDateTime {set;}

						TransferObjectState TransferObjectState {set;}

		}
		public interface Transition  : Object 
		{
						ObjectState FromStates {set;}

						ObjectState ToState {set;}

		}
		public interface UnitOfMeasure  : IUnitOfMeasure, Enumeration 
		{
		}
		public interface UnitOfMeasureConversion  : AccessControlledObject 
		{
						IUnitOfMeasure ToUnitOfMeasure {set;}

						global::System.DateTime? StartDate {set;}

						global::System.Decimal ConversionFactor {set;}

		}
		public interface UtilizationCharge  : PriceComponent 
		{
						global::System.Decimal? Quantity {set;}

						UnitOfMeasure UnitOfMeasure {set;}

		}
		public interface VarianceReason  : Enumeration 
		{
		}
		public interface VatCalculationMethod  : Enumeration 
		{
		}
		public interface VatForm  : AccessControlledObject 
		{
						global::System.String Name {set;}

						VatReturnBox VatReturnBoxes {set;}

		}
		public interface VatRate  : AccessControlledObject 
		{
						VatCalculationMethod VatCalculationMethod {set;}

						VatReturnBox VatReturnBoxes {set;}

						global::System.Decimal Rate {set;}

						OrganisationGlAccount VatPayableAccount {set;}

						Organisation TaxAuthority {set;}

						VatRateUsage VatRateUsage {set;}

						VatRatePurchaseKind VatRatePurchaseKind {set;}

						VatTariff VatTariff {set;}

						TimeFrequency PaymentFrequency {set;}

						OrganisationGlAccount VatToPayAccount {set;}

						EuSalesListType EuSalesListType {set;}

						OrganisationGlAccount VatToReceiveAccount {set;}

						OrganisationGlAccount VatReceivableAccount {set;}

						global::System.Boolean? ReverseCharge {set;}

		}
		public interface VatRatePurchaseKind  : Enumeration 
		{
		}
		public interface VatRateUsage  : Enumeration 
		{
		}
		public interface VatRegime  : Enumeration 
		{
						VatRate VatRate {set;}

						OrganisationGlAccount GeneralLedgerAccount {set;}

		}
		public interface VatReturnBox  : AccessControlledObject 
		{
						global::System.String HeaderNumber {set;}

						global::System.String Description {set;}

		}
		public interface VatReturnBoxType  : AccessControlledObject 
		{
						global::System.String Type {set;}

		}
		public interface VatTariff  : Enumeration 
		{
		}
		public interface Vehicle  : FixedAsset 
		{
		}
		public interface VolumeUsage  : DeploymentUsage 
		{
						global::System.Decimal Quantity {set;}

						UnitOfMeasure UnitOfMeasure {set;}

		}
		public interface Warehouse  : Facility 
		{
		}
		public interface WebAddress  : ElectronicAddress 
		{
		}
		public interface WebSiteCommunication  : CommunicationEvent, Versioned 
		{
						Party Originator {set;}

						Party Receiver {set;}

						WebSiteCommunicationVersion CurrentVersion {set;}

						WebSiteCommunicationVersion AllVersions {set;}

		}
		public interface Withdrawal  : FinancialAccountTransaction 
		{
						Disbursement Disbursement {set;}

		}
		public interface WorkEffortAssignment  : Period, AccessControlledObject, Commentable, Deletable 
		{
						Person Professional {set;}

						WorkEffort Assignment {set;}

		}
		public interface WorkEffortAssignmentRate  : AccessControlledObject 
		{
						RateType RateType {set;}

						WorkEffortPartyAssignment WorkEffortPartyAssignment {set;}

		}
		public interface WorkEffortBilling  : Object 
		{
						WorkEffort WorkEffort {set;}

						global::System.Decimal? Percentage {set;}

						InvoiceItem InvoiceItem {set;}

		}
		public interface WorkEffortFixedAssetAssignment  : Commentable, AccessControlledObject, Period 
		{
						AssetAssignmentStatus AssetAssignmentStatus {set;}

						WorkEffort Assignment {set;}

						global::System.Decimal? AllocatedCost {set;}

						FixedAsset FixedAsset {set;}

		}
		public interface WorkEffortFixedAssetStandard  : AccessControlledObject 
		{
						global::System.Decimal? EstimatedCost {set;}

						global::System.Decimal? EstimatedDuration {set;}

						FixedAsset FixedAsset {set;}

						global::System.Int32? EstimatedQuantity {set;}

		}
		public interface WorkEffortGoodStandard  : AccessControlledObject 
		{
						Good Good {set;}

						global::System.Decimal? EstimatedCost {set;}

						global::System.Int32? EstimatedQuantity {set;}

		}
		public interface WorkEffortInventoryAssignment  : AccessControlledObject 
		{
						WorkEffort Assignment {set;}

						InventoryItem InventoryItem {set;}

						global::System.Int32? Quantity {set;}

		}
		public interface WorkEffortObjectState  : ObjectState 
		{
		}
		public interface WorkEffortPartStandard  : AccessControlledObject 
		{
						Part Part {set;}

						global::System.Decimal? EstimatedCost {set;}

						global::System.Int32? EstimatedQuantity {set;}

		}
		public interface WorkEffortPartyAssignment  : Period, AccessControlledObject, Commentable 
		{
						WorkEffort Assignment {set;}

						Party Party {set;}

						Facility Facility {set;}

		}
		public interface WorkEffortPurpose  : Enumeration 
		{
		}
		public interface WorkEffortSkillStandard  : AccessControlledObject 
		{
						Skill Skill {set;}

						global::System.Int32? EstimatedNumberOfPeople {set;}

						global::System.Decimal? EstimatedDuration {set;}

						global::System.Decimal? EstimatedCost {set;}

		}
		public interface WorkEffortStatus  : Deletable, AccessControlledObject 
		{
						global::System.DateTime StartDateTime {set;}

						WorkEffortObjectState WorkEffortObjectState {set;}

		}
		public interface WorkEffortType  : AccessControlledObject 
		{
						WorkEffortFixedAssetStandard WorkEffortFixedAssetStandards {set;}

						WorkEffortGoodStandard WorkEffortGoodStandards {set;}

						WorkEffortType Children {set;}

						FixedAsset FixedAssetToRepair {set;}

						global::System.String Description {set;}

						WorkEffortType Dependencies {set;}

						WorkEffortTypeKind WorkEffortTypeKind {set;}

						WorkEffortPartStandard WorkEffortPartStandards {set;}

						WorkEffortSkillStandard WorkEffortSkillStandards {set;}

						global::System.Decimal? StandardWorkHours {set;}

						Product ProductToProduce {set;}

						Deliverable DeliverableToProduce {set;}

		}
		public interface WorkEffortTypeKind  : Enumeration 
		{
		}
		public interface WorkFlow  : WorkEffort, Versioned 
		{
						WorkFlowVersion CurrentVersion {set;}

						WorkFlowVersion AllVersions {set;}

		}
		public interface WorkRequirement  : Requirement 
		{
						FixedAsset FixedAsset {set;}

						Deliverable Deliverable {set;}

						Product Product {set;}

		}
		public interface WorkTaskVersion  : WorkEffortVersion 
		{
						global::System.Boolean? SendNotification {set;}

						global::System.Boolean? SendReminder {set;}

						global::System.DateTime? RemindAt {set;}

		}
}