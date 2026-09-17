# API — Aplicação de Gestão de Inventário de Equipamentos

Documentação dos endpoints da API REST (ASP.NET Core Web API), consumida pelo frontend React.

## Base

- **Base URL (desenvolvimento):** `https://localhost:5001/api`
- **Formato:** JSON
- **Autenticação:** todos os endpoints, exceto o login, exigem um token JWT válido no cabeçalho:

  ```
  Authorization: Bearer <token>
  ```

- **Códigos de resposta usados:**
  - `200 OK` — pedido bem-sucedido (GET, PUT)
  - `201 Created` — recurso criado com sucesso (POST)
  - `204 No Content` — remoção bem-sucedida (DELETE)
  - `400 Bad Request` — dados inválidos
  - `401 Unauthorized` — token em falta ou inválido
  - `403 Forbidden` — autenticado, mas sem permissão para a ação
  - `404 Not Found` — recurso não encontrado

## Legenda de acesso

| Nível | Significado |
|---|---|
| Público | Não requer autenticação |
| Autenticado | Qualquer utilizador com sessão válida (Admin, Técnico ou Utilizador normal) |
| Técnico/Admin | Apenas perfis Técnico ou Admin |
| Admin | Apenas perfil Admin |
| Próprio / Admin | O próprio utilizador (sobre os seus dados) ou um Admin |

---

## Autenticação

| Método | Rota | Descrição | Acesso |
|---|---|---|---|
| POST | `/auth/login` | Autentica (email + password) e devolve o token JWT | Público |
| POST | `/auth/register` | Cria uma nova conta de utilizador | Admin |

## Utilizadores

| Método | Rota | Descrição | Acesso |
|---|---|---|---|
| GET | `/utilizadores` | Lista todos os utilizadores | Admin |
| GET | `/utilizadores/{id}` | Detalhe de um utilizador | Admin |
| GET | `/utilizadores/me` | Dados do utilizador autenticado | Autenticado |
| PUT | `/utilizadores/{id}` | Atualiza dados de um utilizador | Admin |
| PUT | `/utilizadores/{id}/password` | Altera a password | Próprio / Admin |
| DELETE | `/utilizadores/{id}` | Remove/desativa a conta | Admin |
| GET | `/utilizadores/{id}/equipamentos` | Equipamentos atribuídos ao utilizador | Autenticado |
| GET | `/utilizadores/{id}/manutencoes` | Manutenções feitas por este técnico | Autenticado |

## Departamentos

| Método | Rota | Descrição | Acesso |
|---|---|---|---|
| GET | `/departamentos` | Lista departamentos | Autenticado |
| GET | `/departamentos/{id}` | Detalhe de um departamento | Autenticado |
| POST | `/departamentos` | Cria um novo departamento | Admin |
| PUT | `/departamentos/{id}` | Atualiza um departamento | Admin |
| DELETE | `/departamentos/{id}` | Remove um departamento | Admin |

## Equipamentos

| Método | Rota | Descrição | Acesso |
|---|---|---|---|
| GET | `/equipamentos` | Lista equipamentos (com filtros/paginação) | Autenticado |
| GET | `/equipamentos/{id}` | Detalhe de um equipamento | Autenticado |
| POST | `/equipamentos` | Cria um novo equipamento | Técnico/Admin |
| PUT | `/equipamentos/{id}` | Atualiza um equipamento | Técnico/Admin |
| DELETE | `/equipamentos/{id}` | Remove um equipamento | Admin |
| GET | `/equipamentos/{id}/manutencoes` | Histórico de manutenção do equipamento | Autenticado |

## Manutenções

| Método | Rota | Descrição | Acesso |
|---|---|---|---|
| GET | `/manutencoes` | Lista todas as manutenções (visão geral) | Técnico/Admin |
| GET | `/manutencoes/{id}` | Detalhe de uma manutenção | Autenticado |
| POST | `/manutencoes` | Regista uma nova manutenção | Técnico/Admin |
| PUT | `/manutencoes/{id}` | Corrige um registo de manutenção | Técnico/Admin |
| DELETE | `/manutencoes/{id}` | Remove um registo de manutenção | Admin |

## Fornecedores

| Método | Rota | Descrição | Acesso |
|---|---|---|---|
| GET | `/fornecedores` | Lista fornecedores | Autenticado |
| GET | `/fornecedores/{id}` | Detalhe de um fornecedor | Autenticado |
| POST | `/fornecedores` | Cria um novo fornecedor | Técnico/Admin |
| PUT | `/fornecedores/{id}` | Atualiza um fornecedor | Técnico/Admin |
| DELETE | `/fornecedores/{id}` | Remove um fornecedor | Admin |

## Alertas e relatórios

| Método | Rota | Descrição | Acesso |
|---|---|---|---|
| GET | `/alertas` | Garantias a expirar / manutenções agendadas | Autenticado |
| GET | `/relatorios/export` | Exporta relatório (PDF ou Excel) | Técnico/Admin |

---

## Notas de implementação

- Todas as rotas sensíveis devem usar o atributo `[Authorize(Roles = "...")]` do ASP.NET Core para aplicar o nível de acesso indicado.
- Os endpoints de listagem (`GET` sem `{id}`) devem suportar paginação e filtros básicos via query string, por exemplo: `GET /equipamentos?departamento=3&estado=ativo&pagina=2`.
- Este documento é o ponto de partida do desenvolvimento da API — deve ser atualizado sempre que um endpoint for adicionado, alterado ou removido durante o projeto.
