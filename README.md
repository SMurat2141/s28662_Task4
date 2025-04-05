Refactoring Goals
****Our primary objectives in refactoring were:

**Separation of Concerns: Isolate data access logic from business logic by introducing a dedicated repository layer.

**Enhanced Maintainability: Replace raw SQL with LINQ queries to leverage compile-time checking and modern C# syntax, making future changes safer and easier.

**Improved Testability: By abstracting data access behind a repository, we can use techniques like in-memory databases to test our queries without a live database.

**Performance Optimization: Utilize EF Core’s AsNoTracking() for read-only operations to reduce the overhead of change tracking.

****Key Components Introduced

**MyDbContext Class
Purpose: Serves as the gateway to the database, encapsulating all database-related configurations.
Responsibilities:
Inherits from EF Core's DbContext.
Declares DbSet properties for our domain models (e.g., Emp, Dept, and Salgrade).
Centralizes configuration for entity mappings and the database connection.
Benefit: Consolidates data access configuration and makes it easier to switch data sources or adjust settings in the future.

**EmpDeptRepository Class
Purpose: Provides a set of LINQ-based methods that mirror the legacy SQL queries, ensuring that existing tests continue to pass while improving code clarity.
Responsibilities:
Implements methods for fetching, filtering, grouping, and aggregating data.
Uses LINQ to translate legacy SQL queries into strongly-typed queries.
Applies AsNoTracking() (or sets the entire context to no-tracking) for performance improvements on read-only operations.
Benefits:
Clean Separation: Isolates data access from business logic, making the codebase more modular.
Improved Performance: Read-only queries are more efficient by avoiding unnecessary tracking.
Easier Maintenance: LINQ queries are easier to read and modify than raw SQL strings, reducing the risk of errors when changes are needed.

!!Note:Im not sure ıf thıs ıs what you what, I did the task as far as I understood!!
