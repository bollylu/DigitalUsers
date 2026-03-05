```mermaid

erDiagram

    %% ── Entités principales ──────────────────────────────────────────

    EFOrganization {
        string Id PK
        string Name
        string Description
    }

    EFDepartment {
        string Id PK
        string Name
        string Description
        string OrganizationId FK
    }

    EFContact {
        string Id PK
        string FirstName
        string LastName
        string Company
        string Title
        string Notes
    }

    EFLocation {
        string Id PK
        string Name
        string Address1
        string Number
        string Address2
        string AddressDetails
        string City
        string ZipCode
        string Country
    }

    EFPhoneNumber {
        string Id PK
        string Number
        string CountryCode
        string Prefix
        string Extension
        string Type
    }

    EFMailAddress {
        string Id PK
        string Address
        string DisplayName
    }

    EFPicture {
        string Id PK
        string Name
        string Description
        string PictureBase64
        string PictureUrl
        string ContactId FK "nullable"
        string LocationId FK "nullable"
    }

    %% ── Tables de jonction ───────────────────────────────────────────

    EFContactDepartment {
        string ContactId FK
        string DepartmentId FK
    }

    EFHodDepartment {
        string ContactId FK
        string DepartmentId FK
    }

    EFContactLocation {
        string ContactId FK
        string LocationId FK
    }

    EFContactPhoneNumber {
        string ContactId FK
        string PhoneNumberId FK
    }

    EFContactMailAddress {
        string ContactId FK
        string MailAddressId FK
    }

    %% ── Relations ────────────────────────────────────────────────────

    %% Organisation → Départements (1 à N obligatoire)
    EFOrganization ||--o{ EFDepartment : "contains"

    %% Organisation → Contacts, Locations, Pictures (1 à N)
    EFOrganization ||--o{ EFContact : "has"
    EFOrganization ||--o{ EFLocation : "has"
    EFOrganization ||--o{ EFPicture : "has"

    %% Contact ↔ Department (N à N via table de jonction)
    EFContact ||--o{ EFContactDepartment : ""
    EFDepartment ||--o{ EFContactDepartment : ""

    %% Contact ↔ Department as HOD (N à N via table de jonction)
    EFContact ||--o{ EFHodDepartment : "heads"
    EFDepartment ||--o{ EFHodDepartment : "headed by"

    %% Contact ↔ Location (N à N via table de jonction)
    EFContact ||--o{ EFContactLocation : ""
    EFLocation ||--o{ EFContactLocation : ""

    %% Pictures (FK nullable vers Contact et Location)
    EFContact ||--o{ EFPicture : "has"
    EFLocation ||--o{ EFPicture : "has"

    %% Contact ↔ PhoneNumber (N à N via table de jonction)
    EFContact ||--o{ EFContactPhoneNumber : ""
    EFPhoneNumber ||--o{ EFContactPhoneNumber : ""

    %% Contact ↔ MailAddress (N à N via table de jonction)
    EFContact ||--o{ EFContactMailAddress : ""
    EFMailAddress ||--o{ EFContactMailAddress : ""

  ```