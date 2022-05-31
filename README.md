# Grammer: Issue Tracking

![GRAMMER logo](https://grammer.jobs.cz/assets/components/header/images/logo.gif?av=0eaee00e00ca86a2)

## DEV: Commit message guidelines

Allowed commit types are `fix:`, `feat:`, `build:`, `chore:`, `ci:`, `docs:`, `style:`, `refactor:`, `perf:` and `test:`;

* `fix:` to resolve bug (this correlates with [**MINOR**](https://semver.org/#summary) in Semantic Versioning);
* `feat:` to add a new feature (this correlates with [**PATCH**](https://semver.org/#summary) in Semantic Versioning);
* `build:` for commits, that involve changes in the build files and dependencies;
* `chore:` for changes that are not related to a feature or a bug, that involves modification or updating dependencies;
* `ci:` for changes in the CI integration;
* `docs:` for changes in the documentation and code comments;
* `style:` for style changes;
* `refactor:` for code refactoring;
* `perf:` for commits improving app's performance;
* `test:` for changes in the test files.

**BREAKING CHANGE**: a commit that has a footer `BREAKING CHANGE:`, or appends a `!` after the type/scope, introduces a breaking API change (correlating with [**MAJOR**](https://semver.org/#summary) in Semantic Versioning). A `BREAKING CHANGE` can be part of commits of any _type_.

For link to GitHub issues, use `refs:` keyword in the footer.

### Examples

#### Commit message with description and breaking change footer

```
feat: Allow provided config object to extend other configs

BREAKING CHANGE: `extends` key in config file is now used for extending other config files
```

#### Commit message with `!` to draw attention to breaking change

```
feat!: Send an email to the customer when a product is shipped
```

#### Commit referencing GitHub issues

```
docs: Add a comprehensive documentation about commit creation

refs: #1, #2, #546
```

### References

* [A Guide to writing Industry Standard Git Commit Message](https://dev.to/tuasegun/a-guide-to-writing-industry-standard-git-commit-message-2ohl)
* [Conventional Commits](https://www.conventionalcommits.org/en/v1.0.0/)
* [conventional-changelog](https://github.com/conventional-changelog/commitlint/tree/master/%40commitlint/config-conventional)

[//]: # (## BUILD:)
