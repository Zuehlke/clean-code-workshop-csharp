# Clean Code Workshop - C#

Repository for the exercise code of the Zühlke Clean Code Workshop for C#.

## Branches

* `master` initial situation as on the A3 handout, checkout `master` (and branch from it) to start with the exercices
* `foundation-solution` solution to the exercises with a single commit per step, compare you solution with this branch

## How to update the solution

1. apply update to initial situation to `master`
2. reformat using Resharper built in cleanup as last commit on `master`
3. `git checkout foundation-solution`
4. `git rebase master`
5. check if solution/tests still work
6. `git push --force-with-lease`
7. `git checkout master`
8. `git rebase -i HEAD~1`
9. delete last commit (reformat)
10. `git push --force-with-lease`