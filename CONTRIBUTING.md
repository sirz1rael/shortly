# Contributing to Shortly

Thank you for your interest in contributing to the project! This document outlines the rules and expectations for contributors to maintain code quality and consistency.

## Core Principles
- Be polite and respectful. Open and constructive communication is encouraged.
- One logical change per pull request.
- Smaller PRs get reviewed faster — break down large changes.

## Getting Started
1. Fork the repository and create a branch with a meaningful name: `feature/<brief-description>` or `fix/<brief-description>`.
2. Make your changes in the new branch.
3. Run tests locally.
4. Open a Pull Request to the `master` branch with a clear description and summary of changes.

## Code Style & Formatting
- The project uses `.editorconfig` (in the root). Please follow its rules. Key points:
  - 4-space indentation
  - LF line endings
  - Interface names prefixed with `I`
  - Private fields use `_` prefix and camelCase
  - Public members use PascalCase
- Run **Format Document** or `dotnet format` before committing.
- Enable nullable reference types in new files where possible.

## Commit Conventions
- Write meaningful commit messages. Recommended format:
  - `feat: adds new functionality`
  - `fix: resolves a bug`
  - `chore: technical changes without behavioral impact`

## Pull Requests
- PRs must include: problem description, solution summary, and testing instructions.
- PRs are validated by CI. Do not merge failing PRs.
- Request reviews from at least one project member.

## Testing
- Add unit tests for new logic.
- Use in-memory SQLite or Testcontainers for integration tests.
- CI must run: `dotnet build`, `dotnet test`, `dotnet format --verify-no-changes`, and static analysis.

## Database & Migrations
- Migrations are managed via EF Core (`dotnet ef migrations add` / `dotnet ef database update`).
- Migrations must be reviewed in a separate branch.
- Production migrations are applied via CI/CD pipeline; avoid automatic `Database.Migrate()` without discussion.

## Secrets & Configuration
- Use **User Secrets** (`dotnet user-secrets`) and `.env` files locally — never commit secrets.
- Use secure secret storage in production (Azure Key Vault, AWS Secrets Manager, etc.).

## CI/CD
- CI must run builds, tests, and static analysis on every PR.
- CD should deploy artifacts and apply migrations only after successful tests and review.

## Security
- Audit external dependencies for vulnerabilities.
- Avoid unsafe policies like `AllowAnyOrigin` in production.

## Contacts
Open an issue or contact the repository owner with questions.
