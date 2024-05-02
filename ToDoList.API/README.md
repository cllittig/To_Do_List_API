# To Do List API

## Esse projeto de fins pessoais tem como objetivo por em praticas habilidades de programção back-end.

1. **Ferramentas utilizadas:** 
    - C#
    - Entity FrameWork Core
    - ASP.net core
    - MySql Server
    - MySql Workbench

2. **Entidades:**

    1. **Users:**
       - UserId (chave primária)
       - UserFirstName
       - USerSecondName
       - UserEmail
       - UserAge
       - UserPassword
       - UserStartDate
       - IsDeleted
       - UserAddress (referencia para criação do relacionamento)
       - UserTasks (referencia para criação do relacionamento)
       - UserCategory (referencia para criação do relacionamento)
       - UserTags (referencia para criação do relacionamento)

    2. **Tasks:**
       - TaskId (chave primária)
       - TaskTitle
       - TaskDescription
       - TaskCreationDate
       - TaskDueDate
       - TaskPriority
       - TaskStatus
       - IsDeleted
       - UserId (chave estrangeira para associar a tarefa ao usuário que a criou)
       - CategoryId (chave estrangeira para associar a tarefa a uma categoria)
       
    3. **Category:**
       - CategoryId (chave primária)
       - CategoryName
       - CategoryDescription
       - IsDeleted
       - CategoryTasks (referencia para relacionamento com as tasks)
       - UserId (chave estrangeira para associar a categoria ao usuário que a criou)

    4. **Tags:**
       - TagId (chave primária)
       - TagName
       - TagDescription (opcional)
       - IsDeleted
       - Task (referencia para relacionamento com tasks)
       - TaskTag (referencia para relacionamento com tasks)
       - UserId (chave estrangeira para associar a tag ao usuário que a criou)

    5. **Address:**
       - ID (chave primária)
       - AddressStreet 
       - AddressNumber
       - AddressComplement
       - AddressCity
       - AddressState
       - AddressPostalCode
       - UserId (chave estrangeira)

    6. **Relacionamento entre Tarefas e Tags (Many-to-Many):**
       - TaskId (chave Composta p1)
       - TagId (chave Composta p2)
       - TagId (referencia para relacionamento)
       - TaskId (referencia para relacionamento)