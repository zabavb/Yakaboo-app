<p align="center">
	<img
		src="https://upload.wikimedia.org/wikipedia/commons/thumb/8/84/Logo_horizontal.png/1200px-Logo_horizontal.png"
		alt="Yakaboo Logo"
		width="500"
		/>
</p>
<h1 align="center">Yakaboo App</h1>
<h2>Project Overview</h2>
<p>
	Yakaboo App is a Windows Forms application developed in C# that allows users
	to manage a collection of books. Users can perform CRUD (Create, Read,
	Update, Delete) operations, and all book data is saved in a database using
	Entity Framework Core. The application connects to an MS SQL Server
	database, making it a practical solution for book management.
</p>
<h2>Project Details</h2>
<ul>
	<li>
		<strong>Languages:</strong>
		<a
			href="https://learn.microsoft.com/en-us/dotnet/csharp/"
			target="_blank">
			<img
				src="https://img.shields.io/badge/C%23-%23239120.svg?style=flat&logo=c-sharp&logoColor=white"
				alt="C#" />
		</a>
	</li>
	<li>
		<strong>Technologies:</strong>
		<a
			href="https://dotnet.microsoft.com/en-us/"
			target="_blank">
			<img
				src="https://img.shields.io/badge/.NET-%235C2D91.svg?style=flat&logo=.net&logoColor=white"
				alt=".NET" />
		</a>
		<a
			href="https://learn.microsoft.com/en-us/sql/sql-server"
			target="_blank">
			<img
				src="https://img.shields.io/badge/MS%20SQL%20Server-%23CC2927.svg?style=flat&logo=microsoft-sql-server&logoColor=white"
				alt="MS SQL Server" />
		</a>
		<a
			href="https://learn.microsoft.com/en-us/ef/core/"
			target="_blank">
			<img
				src="https://img.shields.io/badge/Entity%20Framework%20Core-%230078D4.svg?style=flat&logo=windows-terminal&logoColor=white"
				alt="Entity Framework Core" />
		</a>
    <a
			href="https://learn.microsoft.com/en-us/dotnet/desktop/winforms/?view=netdesktop-7.0"
			target="_blank">
			<img
				src="https://img.shields.io/badge/WinForms-5C2D91?style=flat&logo=windows&logoColor=white"
				alt="WinForms" />
		</a>
	</li>
	<li>
		<strong>IDE:</strong>
		<a
			href="https://visualstudio.microsoft.com/"
			target="_blank">
			<img
				src="https://img.shields.io/badge/Visual%20Studio-5C2D91?style=flat&logo=visual-studio&logoColor=white"
				alt="Visual Studio" />
		</a>
	</li>
</ul>
<h2>Development Details</h2>
<p>
	This project was created as a homework assignment from IT Step Academy and
	was developed exclusively by me on <strong>12.10.2023</strong>. The main
	functionality allows users to manage books in a database by performing CRUD
	operations using Entity Framework Core.
</p>
<h2>Database Notice</h2>
<p>
	<strong>Important:</strong> This project uses MS SQL Server and requires an
	existing database. The connection is managed using Entity Framework Core.
	Ensure your local environment is configured correctly to use SQL Server and
	adjust the context file (line 20) in the code if necessary.
</p>
<h2>Installation</h2>
<p>To install and run this project, follow these steps:</p>
<ol>
	<li>
		Ensure you have the following installed:
		<ul>
			<li>
				<a
					href="https://dotnet.microsoft.com/en-us/download/dotnet/7.0"
					target="_blank"
					>.NET 7.0 SDK</a
				>
			</li>
			<li>
				<a
					href="https://visualstudio.microsoft.com/"
					target="_blank"
					>Visual Studio</a
				>
				with .NET desktop development workload
			</li>
			<li>
				<a
					href="https://www.microsoft.com/en-us/sql-server/sql-server-downloads"
					target="_blank"
					>MS SQL Server</a
				>
			</li>
		</ul>
	</li>
	<li>
		Clone the repository:
		<pre><code>git clone https://github.com/zabavb/Yakaboo-app.git</code></pre>
	</li>
	<li>Open the solution file (<code>.sln</code>) in Visual Studio.</li>
	<li>
		Ensure the database is set up correctly with the connection string in
		<code>Context.cs</code> 20 line.
	</li>
	<li>Press <code>F5</code> to build and run the application.</li>
</ol>
<h2>Features</h2>
<ul>
	<li>
		<strong>Book Management:</strong> Add, edit, view, and delete books from
		the database using a simple WinForms interface.
	</li>
	<li>
		<strong>Entity Framework Core:</strong> Used for data access and
		management in the database.
	</li>
	<li>
		<strong>CRUD Operations:</strong> Full implementation of Create, Read,
		Update, and Delete functionality.
	</li>
</ul>
<h2>Contributing</h2>
<p>
	Contributions are welcome! If you have suggestions or improvements, feel
	free to fork the repository and submit a pull request.
</p>
<ol>
	<li>
		Fork the Repository: Click the "Fork" button at the top-right of this
		page.
	</li>
	<li>Create a Branch: Create a new branch for your changes.</li>
	<li>
		Commit Changes: Make your changes and commit them with a descriptive
		message.
	</li>
	<li>Push to Your Fork: Push your changes to your forked repository.</li>
	<li>
		Submit a Pull Request: Go to the "Pull Requests" tab and submit a new
		pull request.
	</li>
</ol>
<h2>Contact</h2>
<p>
	For any questions or inquiries, you can reach me at
	<a href="mailto:bilonizkavik@agmail.com">email</a> or
	connect with me on
	<a
		href="https://www.linkedin.com/in/viktor-bilonizhka"
		target="_blank"
		>LinkedIn</a
	>.
</p>
<h2>Acknowledgements</h2>
<ul>
	<li>
		Thanks to IT Step Academy for the educational support in this project.
	</li>
	<li>
		Special thanks to the open-source community for tools and resources.
	</li>
</ul>
<hr />
<p align="center">
	Feel free to modify or extend this README to fit your needs better. Happy
	coding!
</p>
