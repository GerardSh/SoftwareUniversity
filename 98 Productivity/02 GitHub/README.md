# General
Най-голямата version control system е Git.
Основната роля е на тази система е колаборацията между хората които пишат код в един и същи проект.

Git е самата система, a GitHub e конкретен вендор или модел, който я представя.

Source control system или version control или source control system са едно и също. Това е мястото където си държим сорс кода в repository и програмистите от екипа, дърпат и изпращат информация.
Ако някой промени нещо в кода, се вижда детайлна информация за тази промяна. Реално имаме пълна история на целия проект, кой кога какво е писал и променял.

Git е сложна система, която някои програмисти управляват чрез Bash - терминал, но това е за по напреднали.
Друг вариант е чрез TortoiseGit, което създава меню когато цъкнем с дясното копче на мишката.
Трети вариант е директно в IDE, чрез extension.
Последния вариант е апликацията на GitHub за десктоп.

В history tab-a може да видим историята с commit-тите на даден файл или цял проект. Също се показват и всичките commits на ниво repository.

В GitHub имам възможност и да логваме задачи и бъгове за проверка и изпълнение. Има също и wiki-та - документация.

Може да добавяме .gitignore file, който игнорира повечето файлове и качва само най-съществените.

Има също и license file, чрез който декларираме дали кода ни е безплатен и при какви условия.
## Terminology
Repo - пази проекта на някой отдалечен сървър. Докато работим, ние работим с локалната версия на компютъра.

Clone - да изтеглим локално копие от сървъра, който държи проекта.

Commit - запазваме направените промени в локалното копие което имаме на GitHub. Добре е през 15-20мин да правим запис на промените. Трябва да слагаме и коментар - commit messages с точните промени които сме направили, един вид summary.

Sync (Pull / Push) - Когато искаме да синхронизираме локалното repository със сървърното, тогава дърпаме или пращаме. Примерно дърпаме, ако колегите са направили промени, които ги нямаме локално. Това не изтрива кода който ние сме commit-вали. 
Понякога може да се получи конфликт ако колегите са променили нещо, което и ние сме променили локално, тогава Git изкарва съобщение с направените промени и пита кое искам да остане финално. Обикновено се прави merge.

Branch - това е за по напреднали, когато става въпрос за големи промени. Примерно ако правим модул, който ще отнеме 2 месеца, няма смисъл да пращаме недовършени неща всеки ден в общото репо, там се очаква само стабилен код. Но пък два месеца да пишем код без да качваме нищо също е проблем, защото е добре да има копие. Тука идва на помощ branch-a, защото може да си качим кода, но той не отива в глобалния общ код, никой не го вижда. Когато сме готови с целия модул, тогава може да го вкараме в общия код.

![](https://github.com/GerardSh/SoftwareUniversity/blob/main/99%20Attachments/Pasted%20image%2020240301103814.png)

Когато сменяме branches през app-а, файловете на локалния компютър се променят според това което има в дадения branch. Реално всички файлове ги има компресирани в git folder-а.

Pull Request - процес когато искаме по опитните програмисти да направят анализ на кода ни и да получим обратна връзка. Тоест когато неопитния програмист реши да качи готов код към общото repository, той иска някой от по-опитните, да го прегледа. Когато бива разгледан, има оставени коментари и забележки. След като се разберете, кода се mergе-ва.

Forking - ако копираме чуждо repository. Това се прави с цел да може да правим комит към сървъра, защото директно на оригиналното репо няма да имаме права. Това е и практиката, когато искаме да създадем pull request, за да contribute-нем даден проект. Иначе може да си свалим репо-то локално, но тогава няма да имаме сървърно копие, което да запази промените ни.
## Commands
`git fetch` - взима най-новата информация от сървъра.
`git status` - показва дали има файлове, които са променени.
`git add` - добавя файл към staging area, може да сложим root directory като path и това ще добави всички промени.
`git commit` - commit-ва файловете които са добавени в staging area-та към repository-то.
`git diff main origin/main` - показва точните промени между сървъра и локалното репо.
`git fetch origin` - взима най-новата информация за конкретно репо.
`git reset --hard origin/main` - reset-ва локалното репо и копира информацията от сървъра.
# Misc
Ако си направим public repository със същото име като username-а и вътре имаме readme file, то информацията вътре ще бъде видима в profile overview. Това се води специално repository. 

Когато има промяна в сървъра и дадем fetch в клиента, ни показва че има commit който трябва да Pull-нем, но не ни показва точната промяна. За да видим промяната във файла, трябва да отворим терминала и от там да дадем въведем командата `git fetch` и после `git diff main origin/main` - може да заместим имената на branch-a. origin/main e repository-то на сървъра, докато main branch-a е локалното repo. 
                                      
При клониране на repository му се дава име, което е [origin](https://github.com/GerardSh/SoftwareUniversity/blob/main/98%20Productivity/02%20GitHub/README.md#remote-name) по default. Ако имаме повече от едно локално repository, трябва да сменим името, за да не стават конфликти. 

Когато commit-ваме през конзолата, реално всеки commit е пълно копие на това как е изглеждала директорията и може да я възстановим в този й вид, ако имаме hash номера на HEAD-а.

Staging area-та е мястото където добавяме променените файлове в работната директория с командата `git add` . Само тези файлове ще влезнат в следващия commit. Така имаме възможност да продължим да работим по даден файл, без да го commit-нем.
# ChatGPT
## Branches
1. **HEAD:**
    
    - In Git, "HEAD" is a special pointer or reference that points to the latest commit in the currently checked-out branch. It essentially represents your current working directory state. When you create a new commit, HEAD is updated to point to that new commit.
    - HEAD can also be detached, meaning it directly points to a specific commit rather than a branch. This happens, for example, when you checkout a specific commit by its hash.
2. **Base Branch:**
    
    - The "base branch" typically refers to the branch into which you want to merge changes. When you create a pull request, you are often asked to specify a base branch and a compare branch. The base branch is the branch into which you want to merge the changes.
    - For example, if you have a feature branch (e.g., feature-branch) and you want to merge it into the main branch, the main branch is your base branch.

When you're working with pull requests, these terms are often used in the context of comparing changes between branches:

- **Base Branch:** The branch you want to merge changes into.
- **Compare Branch:** The branch that contains the changes you want to merge.
## Remote name
Yes, the remote name is a local configuration in your Git repository. When you rename a remote, such as changing from "origin" to "personal" as in the example, this change is only reflected locally in your specific clone of the repository.

The remote name is used as a convenient alias for the URL of the remote repository. It helps you refer to the remote repository using a short and memorable name rather than the full URL. Other collaborators may have different names for the same remote.

When you push or pull changes, Git uses the configured remote names to identify where to send or receive changes. As long as you and your collaborators agree on the remote names, you can use any names that make sense for your workflow.

To summarize, the remote name is a local configuration, and changes to it only affect your local repository. Other collaborators can use their own remote names, and it won't impact your local configuration.
## Mergin
In Git, merging refers to combining changes from different branches. When you merge branches that have diverged and contain conflicting changes (changes to the same lines in the same file), Git may encounter conflicts. Resolving conflicts during a merge involves determining how to combine the conflicting changes.

Here's a breakdown of what happens during a merge in terms of conflicts:

1. **Automated Merging:** When changes from two branches don't conflict, Git can automatically merge them. For example, if you have changes in one branch and the other branch also has changes but in different parts of the code, Git can merge them seamlessly.
    
2. **Conflicts:** Conflicts occur when Git cannot automatically merge changes because both branches have made changes to the same lines in the same file. Git marks these conflicts in the affected files.
    
3. **Conflict Markers:** Git inserts conflict markers (`<<<<<<<`, `=======`, `>>>>>>>`) into the conflicted file. These markers indicate the conflicting sections and help you identify the changes from each branch.
    
    Example conflict marker:
    
    plaintextCopy code
    
    `<<<<<<< HEAD Your local changes ======= Changes from the remote >>>>>>> remote-branch`
    
4. **Manual Resolution:** You, as the developer, need to manually resolve the conflicts by editing the file. Decide which changes to keep and remove the conflict markers. This is where you choose the final state of the conflicting lines.
    
5. **Committing the Resolution:** After resolving conflicts, you need to commit the changes. Git recognizes that the conflict has been resolved based on the removal of conflict markers.
    
    bashCopy code
    
    `git add conflicted-file.txt git commit -m "Merge branchA into branchB with conflict resolution"`
    
6. **Pushing Changes:** If you were merging branches on a remote repository, you would then push the merged changes to the remote repository.
    
Merging doesn't automatically mean keeping both sets of changes; it means integrating changes from different branches. Resolving conflicts during a merge involves deciding on a single set of changes for the conflicting lines.

In your specific case, when you chose to keep the local updated file during the conflict resolution, you were making a manual decision about which changes to incorporate into the final state of the file.

You
oh i see if two people make local commits changing the same file and then the first person who pushes the change will not get a conflict, but the second person will be requested to pull the change and Git will find the conflict in the second person's local copy

ChatGPT

Yes, that's correct. Let's break down the scenario step by step:

1. **Person A and Person B Make Local Commits:**
    
    - Both Person A and Person B make changes to the same file independently in their respective local branches.
2. **Person A Pushes Changes First:**
    
    - Person A pushes their local changes to the remote repository successfully. At this point, the remote repository reflects Person A's changes.
3. **Person B Pushes Changes After Person A:**
    
    - Person B attempts to push their local changes to the remote repository.
    - Git detects that the remote branch has been updated since Person B's last pull, and it prevents the push to avoid overwriting changes made by Person A.
4. **Person B Pulls Changes and Faces Conflict:**
    
    - Person B pulls the changes from the remote repository, which includes Person A's changes.
    - Git detects a conflict because Person B's local changes overlap with the changes made by Person A.
5. **Conflict Resolution:**
    
    - Git marks the conflicting sections in the file, and Person B must manually resolve the conflict by choosing how to integrate their changes with Person A's changes.
    - After resolving the conflict, Person B can commit the changes and then push them to the remote repository.

In collaborative development, it's crucial for team members to communicate and coordinate to avoid conflicts as much as possible. However, when conflicts do occur, resolving them is a standard part of the collaborative development workflow. It's important to handle conflicts carefully to ensure that the final code integrates both sets of changes correctly.
## Commit
Yes, you've captured the essence of Git commits correctly. In Git, a commit represents a snapshot of the entire repository at a specific point in time. When you make a commit, you're creating a new snapshot that includes the state of all tracked files at that moment.

Here's a breakdown of how commits work:

1. **Snapshot:**
    
    - A commit is like a snapshot of your project at a particular point in time. It includes the changes you've made to the files since the last commit.
2. **Unique Identifier (SHA-1 Hash):**
    
    - Each commit is identified by a unique SHA-1 hash. This hash is calculated based on the content of the commit, including the changes, commit message, author information, and so on.
3. **Commit History:**
    
    - Commits are organized into a commit history, forming a chain of snapshots. Each commit points to its parent commit, creating a history of changes.
4. **Branches:**
    
    - Git allows branching, which means you can have multiple independent lines of development. Each branch has its commit history.
5. **Restoring from Commits:**
    
    - You can restore your project to the state of any previous commit by checking out that commit. This effectively reverts your project to the snapshot captured by that commit.
6. **New Commits Build on Previous Commits:**
    
    - When you make a new commit, it includes the changes you've made since the last commit. The new commit becomes the latest snapshot, and the commit history is extended.
7. **Branches as Moveable Pointers:**
    
    - Branches in Git are moveable pointers that point to a specific commit in the commit history. When you create a new commit on a branch, the branch pointer moves forward to the new commit.

By understanding this model, you gain powerful capabilities for version control, collaboration, and project management. Commits provide a way to track changes, revert to previous states, and maintain a chronological history of your project.

Each commit in Git represents a complete snapshot of the entire project at the moment of the commit, not just the changes made in that specific commit. When you make a commit, Git records the state of all files in the repository, including their content, at that particular point in time.

This is often referred to as a "snapshot-based" version control system. It contrasts with "delta-based" systems that only store the changes between versions. In Git, when you look at a commit, you essentially see the entire project as it was at the time of that commit, allowing you to recreate any past state of your project.

While this may seem like it could lead to a large amount of data being stored, Git is quite efficient in managing this information. It uses techniques like content-addressable storage, compression, and clever data structures to keep the repository size reasonable even with a long and complex history.

When you push changes to a remote repository in Git, you are pushing the entire branch, not just the individual changes you made. Git operates based on the concept of changesets and commits, and when you push, you are essentially updating the remote branch with the complete commit history of your local branch.

Here's a breakdown:

1. **Commit History:**
    
    - Each commit in Git represents a snapshot of the entire project at a specific point in time.
2. **Push Operation:**
    
    - When you push changes to a remote repository, you are sending your complete local branch (including all the commits) to the corresponding remote branch.
3. **Complete Snapshot:**
    
    - The remote branch is updated to reflect the complete snapshot of your local branch's commit history.
4. **Fetch and Pull:**
    
    - Conversely, when you fetch or pull changes from a remote repository, you are retrieving the entire branch history from the remote, not just the changes made since your last pull.

This approach ensures that the complete history of the branch is maintained, allowing Git to track changes and manage collaboration effectively. It's different from systems that only track and transmit the specific changes made in each commit. The trade-off is that Git's approach can result in larger repositories, but it provides a more comprehensive and detailed version history.

## Staging Area
The staging area, also known as the "index" in Git, is an intermediate area where you prepare and organize changes before committing them to the version control system. It sits between your working directory (where you make modifications) and the actual repository (where committed changes are stored in the version history).

Here's a brief overview of how the staging area works:

1. **Working Directory:**
    
    - This is where you make modifications to your project—edit files, add new files, or delete existing ones.
2. **Staging Area:**
    
    - The staging area is a space where you select which changes you want to include in the next commit. It acts as a kind of checkpoint between your working directory and the repository. Files in the staging area are ready to be committed.
    - You use the `git add` command to move changes from the working directory to the staging area.
3. **Repository:**
    
    - Once you are satisfied with the changes in the staging area, you commit them to the repository using the `git commit` command. This permanently records the changes in the version history.

Using the staging area provides several advantages:

- **Selective Commits:** You can choose specific changes or files to include in a commit, even if you've made changes to multiple files. This allows for more granular and organized commits.
    
- **Review Changes:** Before committing, you can review the changes in the staging area to ensure you are including what you intend.
    
- **Commit in Stages:** If you're working on multiple features or bug fixes simultaneously, you can commit changes for one feature at a time by selectively adding and committing from the staging area.
    

The typical workflow involves making changes in your working directory, using `git add` to stage those changes, and then committing them with `git commit`. The staging area adds an extra layer of control and flexibility to the Git version control process.
## Tracked and Untracked Files
so for example if i add a new file to the directory before i commit it it is untracked
ChatGPT
Exactly, that's correct. When you add a new file to a Git repository, it starts as an untracked file. Git is aware of the file's existence in your working directory, but it hasn't been added to the version control system yet.

Here are the typical steps for adding a new file to a Git repository:

1. **Create a new file:**
    
    bashCopy code
    
    `touch new_file.txt`
    
2. **Check the status:**
    
    bashCopy code
    
    `git status`
    
    At this point, you'll likely see `new_file.txt` listed as an untracked file.
    
3. **Stage the new file:**
    
    bashCopy code
    
    `git add new_file.txt`
    
    Now, the file is staged for the next commit.
    
4. **Commit the changes:**
    
    bashCopy code
    
    `git commit -m "Add new_file.txt"`
    
    This commits the staged changes, including the addition of `new_file.txt`, to the Git repository.

After these steps, `new_file.txt` becomes a tracked file, and its changes will be part of the Git history. Subsequent modifications to this file can be tracked and committed using the usual Git workflow.
## Working with local Repos
So if i navigate to the repoA folder and execute git status it will get the status of repoA if then go to the repoB folder and execute git status it will get the repoB status is this correct? What will happen if i then go to the root folder containing both repoA and repoB and execute git status
ChatGPT
Yes, you're correct. If you navigate to the `repoA` folder and execute `git status`, it will show the status of `repoA`. Similarly, if you go to the `repoB` folder and execute `git status`, it will display the status of `repoB`.

Now, if you go to the root folder containing both `repoA` and `repoB` and execute `git status`, Git will recognize that you are not inside a specific repository. Instead, it will give you an error message like:

bashCopy code

`fatal: not a git repository (or any of the parent directories): .git`

This error indicates that Git couldn't find a Git repository in the current working directory or any of its parent directories. Git relies on the presence of a `.git` directory to determine if a folder is a Git repository.

So, when you are in the root folder containing multiple repositories and you execute `git status`, Git won't be able to determine which repository to operate on, and it will result in an error.

If you want to check the status of each repository, you need to navigate to each repository's directory (`repoA` and `repoB`) separately and run `git status` within each. Git commands operate within the context of the current working directory, and each repository is independent of others.
# Bookmarks 

Course completion: 03.03.2024
