1. **Usuários:**
   - ID (chave primária)
   - Nome de usuário
   - E-mail
   - Senha (hash)
   - Data de criação

2. **Tarefas:**
   - ID (chave primária)
   - Título
   - Descrição
   - Data de criação
   - Data de vencimento
   - Prioridade (baixa, média, alta, etc.)
   - Status (pendente, em andamento, concluída, etc.)
   - ID do usuário (chave estrangeira para associar a tarefa ao usuário que a criou)

3. **Categorias:**
   - ID (chave primária)
   - Nome da categoria
   - Descrição da categoria (opcional)
   - ID do usuário (chave estrangeira para associar a categoria ao usuário que a criou)

4. **Tags:**
   - ID (chave primária)
   - Nome da tag
   - Descrição da tag (opcional)
   - ID do usuário (chave estrangeira para associar a tag ao usuário que a criou)

5. **Relacionamento entre Tarefas e Categorias (Many-to-Many):**
   - ID da relação (chave primária)
   - ID da tarefa (chave estrangeira referenciando a tabela de tarefas)
   - ID da categoria (chave estrangeira referenciando a tabela de categorias)

6. **Relacionamento entre Tarefas e Tags (Many-to-Many):**
   - ID da relação (chave primária)
   - ID da tarefa (chave estrangeira referenciando a tabela de tarefas)
   - ID da tag (chave estrangeira referenciando a tabela de tags)
