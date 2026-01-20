
Mistakes : 

1. Infrastructure was mistakenly created as a Web API instead of a Class Library, which caused EF Core startup confusion.

2. Web API and Class Library projects were created in different locations, leading to broken references and DbContext detection issues.

3. EF Core tooling did not support .NET SDK 10, so migration commands failed.

4. After installing .NET SDK 8, errors like “Multiple DbContext found” occurred due to the earlier incorrect project structure and locations.

5. After fixing project type, folder structure, SDK version, and startup configuration, migrations were added successfully.

