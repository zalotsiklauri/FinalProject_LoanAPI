
# Final Project LoanAPI
## User API Reference

#### [User] Login

```http
    POST /api/User/login
```

| Parameter | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `username` | `string` | **Required**. User Username |
| `password` | `string` | **Required**. User Password |

```json
{
    "username": "string",
    "password": "string"
}
```

#### [User] Registration

```http
    POST /api/User/reg
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `username` | `string` | **Required**. User Username |
| `password` | `string` | **Required**. User Password |
| `email`    | `string` | **Required**. User Email |
| `firstName`| `string` | **Required**. User FirstName |
| `lastName` | `string` | **Required**. User LastName |
| `age`      | `int` | **Required**. User Age |
| `salary`   | `int` | **Required**. User Salary |

```json
{
    "username": "string",
    "password": "string",
    "email": "string",
    "firstName": "string",
    "lastName": "string",
    "age": 0,
    "salary": 0
}
```
#### [User] Request Loan (Requesting Loan)

```http
    POST /api​/User​/RequestLoan
```
| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `loanType` | `int` | **Required**. Loan Type |
| `loanAmount` | `int` | **Required**. Loan Amount |
| `currency`    | `string` | **Required**. Loan Vurrency |
| `loanPeriod` | `int` | **Required**. Loan Period Monthly |

```json
{
    "loanType": 0,
    "loanAmount": 0,
    "currency": "string",
    "loanPeriod": 0,
}
```
#### [User] Update Loan (Update Loan By Loan Id)

```http
    PUT /api/User/UpdateLoan/{id} 
```
| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `loanType` | `int` | **Required**. Loan Type |
| `loanAmount` | `int` | **Required**. Loan Amount |
| `currency`    | `string` | **Required**. Loan Vurrency |
| `loanPeriod` | `int` | **Required**. Loan Period Monthly |

```json
{
    "loanType": 0,
    "loanAmount": 0,
    "currency": "string",
    "loanPeriod": 0
}
```

#### [User] Delete Loan (Delete Loan By Loan Id)

```http
    DELETE /api​/User​/DeleteLoan​/{id}
```
| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `id` | `int` | **Required**. Loan ID |



## Accountant API Reference

### [Accountant] Get All User List (Return All Users From dbo.User Table)

```http
    GET /api​/Accountant​/GetUserList
```
### [Accountant] Remove User (Remove User By User Id)

```http
    DELETE /api/Accountant/RemoveUserById/{id}
```
| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `id` | `int` | **Required**. User ID |

### [Accountant] Remove Loan (Remove Loan By Loan Id)

```http
    DELETE /api/Accountant/RemoveLoanById/{id}
```
| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `id` | `int` | **Required**. Loan ID |

### [Accountant] Update Loan Status (Update Loan Status By Loan Id)

```http
    PUT /api/Accountant/UpdateLoanStatus/{id}/{status}
```
| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `id` | `int` | **Required**. Loan ID |
| `status` | `int` | **Required**. Loan Status|

### [Accountant] Block or Unblock User (Block or Unblock User by User Id )

```http
    PUT /api​/Accountant​/BlockUnblockUserById​/{id}
```
| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `id` | `int` | **Required**. User ID |

### [Accountant] Get All User Loans (Get All User Loans By User Id)

```http
    PUT /api/Accountant/GetLoansByUserId/{id}
```
| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `id` | `int` | **Required**. Loan ID |


# NugetPackages

* **Microsoft.AspNet.WebApi.Core**
* **Microsoft.Entity.FrameworkCore**
* **Microsoft.EntityFrameworkCore.Tools**
* **Microsoft.AspNetCore.Authentication.JwtBearer**
* **System.Data.SqlClient**
* **FluentValidation**
* **Serilog.AspNetCore**
* **Serilog.Sinks.Console**
* **Serilog.Sinks.MSSqlServer**

# Variables

## LoanStatuses
```c#
    public class LoanStatus
    {
        public const int Pending = 1;
        public const int Approved = 2;
        public const int Rejected = 3;
    }
```
## LoanTypes
```c#
    public class LoanTypes
    {
        public const int Mortgage = 1;
        public const int Consumer = 2;
        public const int Car = 3;
    }
```
## Roles
```c#
    public class Role
    {
        public const string Accountant = "Accountant";
        public const string User = "User";
    }
```