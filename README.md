# 🏫 Gadeia’s Cursos - Sistema de Gestão Escolar

[cite_start]O **Gadeia’s Cursos** é uma aplicação web completa voltada para a gestão de uma escola de cursos livres[cite: 1]. [cite_start]O sistema foi projetado para gerir com precisão o ciclo de vida dos alunos, matrículas, turmas, tutores, cursos e módulos de aulas, garantindo a integridade dos dados por meio de regras de negócio bem definidas[cite: 1, 3, 12, 18, 25, 47].

---

## 🚀 Módulos e Regras de Negócio

### 1. Módulo de Alunos
* [cite_start]**Funcionalidades:** Cadastro, edição, exclusão e visualização de alunos[cite: 3].
* [cite_start]**Campos Obrigatórios:** Nome completo (2 a 100 caracteres) [cite: 6][cite_start], Telefone no formato `(DDD) 9XXXX-XXXX` [cite: 7][cite_start], CPF (11 caracteres) [cite: 8] [cite_start]e vínculo de Matrícula[cite: 9].
* **Regras de Negócio:**
  * [cite_start]Não é permitido o cadastro de alunos com o mesmo CPF[cite: 10].
  * [cite_start]Não é possível excluir alunos que possuam uma matrícula com situação **ATIVA**[cite: 10].
  * [cite_start]Um aluno não poderá ser matriculado mais de uma vez na mesma turma[cite: 10].

### 2. Módulo de Categorias
* [cite_start]**Funcionalidades:** Cadastro, edição, exclusão e listagem de categorias de cursos[cite: 12].
* [cite_start]**Campos Obrigatórios:** Título (2 a 100 caracteres)[cite: 15].
* [cite_start]**Regras de Negócio:** Não pode haver categorias com o mesmo nome no sistema[cite: 16].

### 3. Módulo de Tutores
* [cite_start]**Funcionalidades:** Cadastro, edição, exclusão e listagem de tutores/professores[cite: 18].
* [cite_start]**Campos Obrigatórios:** Nome completo (2 a 100 caracteres) [cite: 20][cite_start], Telefone no formato `(DDD) 9XXXX-XXXX` [cite: 21] [cite_start]e CPF (11 caracteres)[cite: 22].
* [cite_start]**Regras de Negócio:** Não é permitido o cadastro de tutores com o mesmo CPF[cite: 23].

### 4. Módulo de Cursos
* [cite_start]**Funcionalidades:** Cadastro, edição, exclusão e listagem de cursos[cite: 25].
* [cite_start]**Campos Obrigatórios:** Nome do curso (2 a 100 caracteres) [cite: 27][cite_start], Carga Horária [cite: 28][cite_start], Nível de Dificuldade (Enum) [cite: 29][cite_start], Categoria vinculada [cite: 30] [cite_start]e Lista de aulas/módulos[cite: 31].
* **Regras de Negócio:**
  * [cite_start]A carga horária deve ser obrigatoriamente um valor maior que zero[cite: 32].
  * [cite_start]Não pode haver cursos duplicados com o mesmo nome[cite: 33].

### 5. Módulo de Aulas / Módulos
* [cite_start]**Funcionalidades:** Gerido diretamente através da página de Listagem de Cursos, permitindo adicionar, remover, editar e visualizar as aulas de um curso[cite: 35, 36, 37, 38, 39].
* [cite_start]**Campos Obrigatórios:** Nome da Matéria [cite: 41][cite_start], Créditos da Matéria [cite: 42] [cite_start]e a identificação do Curso (`CursoId`)[cite: 43].
* [cite_start]**Regras de Negócio:** Não pode haver matérias/aulas com o mesmo nome dentro do sistema[cite: 44].

### 6. Módulo de Turmas
* [cite_start]**Funcionalidades:** Cadastro, edição, exclusão e visualização de turmas organizadas[cite: 47].
* [cite_start]**Campos Obrigatórios:** Título (2 a 100 caracteres) [cite: 49][cite_start], Capacidade Máxima de alunos [cite: 50][cite_start], Tutor responsável [cite: 51][cite_start], Curso base [cite: 52] [cite_start]e Lista de Alunos vinculados[cite: 53].
* **Regras de Negócio:**
  * [cite_start]A quantidade de alunos matriculados não pode exceder a capacidade máxima definida para a turma[cite: 54].
  * [cite_start]Toda turma deve obrigatoriamente ser atribuída a um curso ativo[cite: 55].
  * [cite_start]O título de cada turma deve ser único[cite: 56].

### 7. Módulo de Matrícula
* [cite_start]**Funcionalidades:** Gerido através da página de Listagem de Turmas, permitindo o cadastro, remoção, edição e visualização do histórico de matrículas dos alunos[cite: 58, 59, 60, 61, 62].
* [cite_start]**Campos Obrigatórios:** Data de Matrícula [cite: 64][cite_start], Situação (Ativa ou Não) [cite: 65][cite_start], identificação do Aluno (`IdAluno`) [cite: 66] [cite_start]e identificação da Turma (`IdTurma`)[cite: 67].
