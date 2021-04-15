using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dimension",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dimension", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Morty",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: false),
                    Occupation = table.Column<string>(nullable: true),
                    RickId = table.Column<int>(nullable: false),
                    DimensionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Morty", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Morty_Dimension_DimensionId",
                        column: x => x.DimensionId,
                        principalTable: "Dimension",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rick",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Image = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: false),
                    Occupation = table.Column<string>(nullable: true),
                    Species = table.Column<string>(nullable: true),
                    DimensionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rick", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rick_Dimension_DimensionId",
                        column: x => x.DimensionId,
                        principalTable: "Dimension",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rick_Morty_Id",
                        column: x => x.Id,
                        principalTable: "Morty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RickDimension",
                columns: table => new
                {
                    RickId = table.Column<int>(nullable: false),
                    DimensionId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RickDimension", x => new { x.RickId, x.DimensionId });
                    table.ForeignKey(
                        name: "FK_RickDimension_Dimension_Id",
                        column: x => x.Id,
                        principalTable: "Dimension",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RickDimension_Rick_Id",
                        column: x => x.Id,
                        principalTable: "Rick",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Dimension",
                columns: new[] { "Id", "Description", "Image", "Name" },
                values: new object[,]
                {
                    { 1, null, "https://static.wikia.nocookie.net/rickandmorty/images/3/31/BlumbusTree.png", "Blumbus Dimension" },
                    { 24, null, "https://static.wikia.nocookie.net/rickandmorty/images/4/4c/S4e1_2019-11-13-12h28m17s984.png", "Fascist Dystopian Universe" },
                    { 25, null, "https://static.wikia.nocookie.net/rickandmorty/images/a/a0/4th_Dimensional_Time_Cop_Headquarters.png", "Fourth Dimension" },
                    { 26, null, "https://static.wikia.nocookie.net/rickandmorty/images/e/e4/Froopyland.png", "Froopyland" },
                    { 27, null, "https://static.wikia.nocookie.net/rickandmorty/images/c/cd/Furniture.png", "Furniture Universe" },
                    { 28, null, "https://static.wikia.nocookie.net/rickandmorty/images/1/18/Greasy_Grandma_World.jpg", "Glaagablaaga" },
                    { 29, null, "https://static.wikia.nocookie.net/rickandmorty/images/1/18/Greasy_Grandma_World.jpg", "Greasy Grandma World" },
                    { 30, null, "https://static.wikia.nocookie.net/rickandmorty/images/e/e2/Hamster_in_the_Butt_World.png", "Hamster in Butt World" },
                    { 31, null, "https://static.wikia.nocookie.net/rickandmorty/images/2/27/S3e7_blender_dimsension.png", "List of Realities" },
                    { 23, null, "https://static.wikia.nocookie.net/rickandmorty/images/6/62/Rick_and_Morty_Issue_29_Dimension.png", "Fascist dimension" },
                    { 32, null, "https://static.wikia.nocookie.net/rickandmorty/images/3/32/A346FA1A-2CA1-42DA-B806-C1D3D33AEB3B.png", "Merged Universe" },
                    { 34, null, "https://static.wikia.nocookie.net/rickandmorty/images/e/e7/2_-_One_large_sofa_chair_with_extra_chair_please.png", "Phone Universe" },
                    { 35, null, "https://static.wikia.nocookie.net/rickandmorty/images/1/12/Pizza_Dimension.png", "Pizza Universe" },
                    { 36, null, "https://static.wikia.nocookie.net/rickandmorty/images/f/f4/Post-Apocalyptic_World.png", "Post-Apocalyptic Dimension" },
                    { 37, null, "https://static.wikia.nocookie.net/rickandmorty/images/0/00/Replacementpaper.png", "Replacement dimension" },
                    { 38, null, "https://static.wikia.nocookie.net/rickandmorty/images/1/1b/Screen_Shot_2014-04-14_at_23.41.41.png", "Reverse Height Universe" },
                    { 39, null, "https://static.wikia.nocookie.net/rickandmorty/images/2/2f/S4e1_2019-11-13-12h35m46s019.png", "Shrimp Universe" },
                    { 40, null, "https://static.wikia.nocookie.net/rickandmorty/images/d/df/Testicle_Monster_Dimension.png", "Testicle Monster Dimension" },
                    { 41, null, "https://static.wikia.nocookie.net/rickandmorty/images/b/b1/Toilet_bathroom.png", "Toilet Dimension" },
                    { 33, null, "https://static.wikia.nocookie.net/rickandmorty/images/1/16/PantlessBaseball.png", "Pantless Universe" },
                    { 42, null, "https://static.wikia.nocookie.net/rickandmorty/images/5/5a/S4e3_2019-11-28-13h16m58s807.png", "Tusk Dimension" },
                    { 22, null, "https://static.wikia.nocookie.net/rickandmorty/images/d/df/Fantasyplanet.png", "Fantasy World" },
                    { 20, null, "https://static.wikia.nocookie.net/rickandmorty/images/0/0c/S1e2_dog_world_portal.png", "Dog Dimension" },
                    { 2, null, "https://static.wikia.nocookie.net/rickandmorty/images/2/24/Butt_Dimension.jpg", "Buttworld" },
                    { 3, null, "https://static.wikia.nocookie.net/rickandmorty/images/e/ed/Rick-and-morty-corn-world-750x400.jpg", "Corn Universe" },
                    { 4, null, "https://static.wikia.nocookie.net/rickandmorty/images/e/ed/Cromulon_Dimension.png", "Cromulon Dimension" },
                    { 5, null, "https://static.wikia.nocookie.net/rickandmorty/images/e/e3/No_Image.png", "Cronenberg World" },
                    { 6, null, "https://static.wikia.nocookie.net/rickandmorty/images/4/41/Morty_Smith.jpg", "Dimension 9-2184C" },
                    { 7, null, "https://static.wikia.nocookie.net/rickandmorty/images/0/00/S1e1_dimension_35C.png", "Dimension 35-C" },
                    { 8, null, "https://static.wikia.nocookie.net/rickandmorty/images/7/7f/Dimension46Earth.png", "Dimension 46" },
                    { 9, null, "https://static.wikia.nocookie.net/rickandmorty/images/9/9c/Dimension_304-X.png", "Dimension 304-X" },
                    { 21, null, "https://static.wikia.nocookie.net/rickandmorty/images/2/23/Doopidoo_Dimension.jpg", "Doopidoo Dimension" },
                    { 10, null, "https://static.wikia.nocookie.net/rickandmorty/images/0/02/Dimension_437.png", "Dimension 437" },
                    { 12, null, "https://static.wikia.nocookie.net/rickandmorty/images/6/64/Dimension_C-132.png", "Dimension C-132" },
                    { 13, null, "https://static.wikia.nocookie.net/rickandmorty/images/9/9a/Rick-and-morty-rick-potion-number-9-cronenbergs-1280px.jpg", "Dimension C-137" },
                    { 14, null, "https://static.wikia.nocookie.net/rickandmorty/images/2/20/C500A_copy.jpg", "Dimension C-500A" },
                    { 15, null, "https://static.wikia.nocookie.net/rickandmorty/images/7/70/Summer_C-1239.png", "Dimension C-1239" },
                    { 16, null, "https://static.wikia.nocookie.net/rickandmorty/images/f/fd/Dimension_C-4499.png", "Dimension C-4499" },
                    { 17, null, "https://static.wikia.nocookie.net/rickandmorty/images/d/df/J19alpha7.png", "Dimension J19α7" },
                    { 18, null, "https://static.wikia.nocookie.net/rickandmorty/images/2/27/S3e7_blender_dimsension.png", "Dimension J19ζ7" },
                    { 19, null, "https://static.wikia.nocookie.net/rickandmorty/images/2/27/S3e7_blender_dimsension.png", "Dimension Zeta-6 Epsilon" },
                    { 11, null, "https://static.wikia.nocookie.net/rickandmorty/images/8/8d/Opening_3_face_butts.png", "Dimension Beta B-45" },
                    { 43, null, "https://static.wikia.nocookie.net/rickandmorty/images/f/f1/S4e1_2019-11-13-12h56m54s682.png", "Wasp Universe" }
                });

            migrationBuilder.InsertData(
                table: "Morty",
                columns: new[] { "Id", "Age", "DimensionId", "Image", "Name", "Occupation", "RickId" },
                values: new object[,]
                {
                    { 1, 14, 1, "https://rickandmortyapi.com/api/character/avatar/2.jpeg", "Morty Smith (Blumbus Dimension)", "Student", 1 },
                    { 24, 14, 24, "https://rickandmortyapi.com/api/character/avatar/2.jpeg", "Morty Smith (Fascist Dystopian Universe)", "Student", 24 },
                    { 25, 14, 25, "https://rickandmortyapi.com/api/character/avatar/2.jpeg", "Morty Smith (Fourth Dimension)", "Student", 25 },
                    { 26, 14, 26, "https://rickandmortyapi.com/api/character/avatar/2.jpeg", "Morty Smith (Froopyland)", "Student", 26 },
                    { 27, 14, 27, "https://rickandmortyapi.com/api/character/avatar/2.jpeg", "Morty Smith (Furniture Universe)", "Student", 27 },
                    { 28, 14, 28, "https://rickandmortyapi.com/api/character/avatar/2.jpeg", "Morty Smith (Glaagablaaga)", "Student", 28 },
                    { 29, 14, 29, "https://rickandmortyapi.com/api/character/avatar/2.jpeg", "Morty Smith (Greasy Grandma World)", "Student", 29 },
                    { 30, 14, 30, "https://rickandmortyapi.com/api/character/avatar/2.jpeg", "Morty Smith (Hamster in Butt World)", "Student", 30 },
                    { 31, 14, 31, "https://rickandmortyapi.com/api/character/avatar/2.jpeg", "Morty Smith (List of Realities)", "Student", 31 },
                    { 23, 14, 23, "https://rickandmortyapi.com/api/character/avatar/2.jpeg", "Morty Smith (Fascist dimension)", "Student", 23 },
                    { 32, 14, 32, "https://rickandmortyapi.com/api/character/avatar/2.jpeg", "Morty Smith (Merged Universe)", "Student", 32 },
                    { 34, 14, 34, "https://rickandmortyapi.com/api/character/avatar/2.jpeg", "Morty Smith (Phone Universe)", "Student", 34 },
                    { 35, 14, 35, "https://rickandmortyapi.com/api/character/avatar/2.jpeg", "Morty Smith (Pizza Universe)", "Student", 35 },
                    { 36, 14, 36, "https://rickandmortyapi.com/api/character/avatar/2.jpeg", "Morty Smith (Post-Apocalyptic Dimension)", "Student", 36 },
                    { 37, 14, 37, "https://rickandmortyapi.com/api/character/avatar/2.jpeg", "Morty Smith (Replacement dimension)", "Student", 37 },
                    { 38, 14, 38, "https://rickandmortyapi.com/api/character/avatar/2.jpeg", "Morty Smith (Reverse Height Universe)", "Student", 38 },
                    { 39, 14, 39, "https://rickandmortyapi.com/api/character/avatar/2.jpeg", "Morty Smith (Shrimp Universe)", "Student", 39 },
                    { 40, 14, 40, "https://rickandmortyapi.com/api/character/avatar/2.jpeg", "Morty Smith (Testicle Monster Dimension)", "Student", 40 },
                    { 41, 14, 41, "https://rickandmortyapi.com/api/character/avatar/2.jpeg", "Morty Smith (Toilet Dimension)", "Student", 41 },
                    { 33, 14, 33, "https://rickandmortyapi.com/api/character/avatar/2.jpeg", "Morty Smith (Pantless Universe)", "Student", 33 },
                    { 42, 14, 42, "https://rickandmortyapi.com/api/character/avatar/2.jpeg", "Morty Smith (Tusk Dimension)", "Student", 42 },
                    { 22, 14, 22, "https://rickandmortyapi.com/api/character/avatar/2.jpeg", "Morty Smith (Fantasy World)", "Student", 22 },
                    { 20, 14, 20, "https://rickandmortyapi.com/api/character/avatar/2.jpeg", "Morty Smith (Dog Dimension)", "Student", 20 },
                    { 2, 14, 2, "https://rickandmortyapi.com/api/character/avatar/2.jpeg", "Morty Smith (Buttworld)", "Student", 2 },
                    { 3, 14, 3, "https://rickandmortyapi.com/api/character/avatar/2.jpeg", "Morty Smith (Corn Universe)", "Student", 3 },
                    { 4, 14, 4, "https://rickandmortyapi.com/api/character/avatar/2.jpeg", "Morty Smith (Cromulon Dimension)", "Student", 4 },
                    { 5, 14, 5, "https://rickandmortyapi.com/api/character/avatar/2.jpeg", "Morty Smith (Cronenberg World)", "Student", 5 },
                    { 6, 14, 6, "https://rickandmortyapi.com/api/character/avatar/2.jpeg", "Morty Smith (Dimension 9-2184C)", "Student", 6 },
                    { 7, 14, 7, "https://rickandmortyapi.com/api/character/avatar/2.jpeg", "Morty Smith (Dimension 35-C)", "Student", 7 },
                    { 8, 14, 8, "https://rickandmortyapi.com/api/character/avatar/2.jpeg", "Morty Smith (Dimension 46)", "Student", 8 },
                    { 9, 14, 9, "https://rickandmortyapi.com/api/character/avatar/2.jpeg", "Morty Smith (Dimension 304-X)", "Student", 9 },
                    { 21, 14, 21, "https://rickandmortyapi.com/api/character/avatar/2.jpeg", "Morty Smith (Doopidoo Dimension)", "Student", 21 },
                    { 10, 14, 10, "https://rickandmortyapi.com/api/character/avatar/2.jpeg", "Morty Smith (Dimension 437)", "Student", 10 },
                    { 12, 14, 12, "https://rickandmortyapi.com/api/character/avatar/2.jpeg", "Morty Smith (Dimension C-132)", "Student", 12 },
                    { 13, 14, 13, "https://rickandmortyapi.com/api/character/avatar/2.jpeg", "Morty Smith (Dimension C-137)", "Student", 13 },
                    { 14, 14, 14, "https://rickandmortyapi.com/api/character/avatar/2.jpeg", "Morty Smith (Dimension C-500A)", "Student", 14 },
                    { 15, 14, 15, "https://rickandmortyapi.com/api/character/avatar/2.jpeg", "Morty Smith (Dimension C-1239)", "Student", 15 },
                    { 16, 14, 16, "https://rickandmortyapi.com/api/character/avatar/2.jpeg", "Morty Smith (Dimension C-4499)", "Student", 16 },
                    { 17, 14, 17, "https://rickandmortyapi.com/api/character/avatar/2.jpeg", "Morty Smith (Dimension J19α7)", "Student", 17 },
                    { 18, 14, 18, "https://rickandmortyapi.com/api/character/avatar/2.jpeg", "Morty Smith (Dimension J19ζ7)", "Student", 18 },
                    { 19, 14, 19, "https://rickandmortyapi.com/api/character/avatar/2.jpeg", "Morty Smith (Dimension Zeta-6 Epsilon)", "Student", 19 },
                    { 11, 14, 11, "https://rickandmortyapi.com/api/character/avatar/2.jpeg", "Morty Smith (Dimension Beta B-45)", "Student", 11 },
                    { 43, 14, 43, "https://rickandmortyapi.com/api/character/avatar/2.jpeg", "Morty Smith (Wasp Universe)", "Student", 43 }
                });

            migrationBuilder.InsertData(
                table: "Rick",
                columns: new[] { "Id", "Age", "DimensionId", "Image", "Name", "Occupation", "Species" },
                values: new object[,]
                {
                    { 1, 70, 1, "https://rickandmortyapi.com/api/character/avatar/1.jpeg", "Rick Sanchez (Blumbus Dimension)", "Scientist", "Human (Cyborg)" },
                    { 24, 70, 24, "https://rickandmortyapi.com/api/character/avatar/1.jpeg", "Rick Sanchez (Fascist Dystopian Universe)", "Scientist", "Human (Cyborg)" },
                    { 25, 70, 25, "https://rickandmortyapi.com/api/character/avatar/1.jpeg", "Rick Sanchez (Fourth Dimension)", "Scientist", "Human (Cyborg)" },
                    { 26, 70, 26, "https://rickandmortyapi.com/api/character/avatar/1.jpeg", "Rick Sanchez (Froopyland)", "Scientist", "Human (Cyborg)" },
                    { 27, 70, 27, "https://rickandmortyapi.com/api/character/avatar/1.jpeg", "Rick Sanchez (Furniture Universe)", "Scientist", "Human (Cyborg)" },
                    { 28, 70, 28, "https://rickandmortyapi.com/api/character/avatar/1.jpeg", "Rick Sanchez (Glaagablaaga)", "Scientist", "Human (Cyborg)" },
                    { 29, 70, 29, "https://rickandmortyapi.com/api/character/avatar/1.jpeg", "Rick Sanchez (Greasy Grandma World)", "Scientist", "Human (Cyborg)" },
                    { 30, 70, 30, "https://rickandmortyapi.com/api/character/avatar/1.jpeg", "Rick Sanchez (Hamster in Butt World)", "Scientist", "Human (Cyborg)" },
                    { 31, 70, 31, "https://rickandmortyapi.com/api/character/avatar/1.jpeg", "Rick Sanchez (List of Realities)", "Scientist", "Human (Cyborg)" },
                    { 23, 70, 23, "https://rickandmortyapi.com/api/character/avatar/1.jpeg", "Rick Sanchez (Fascist dimension)", "Scientist", "Human (Cyborg)" },
                    { 32, 70, 32, "https://rickandmortyapi.com/api/character/avatar/1.jpeg", "Rick Sanchez (Merged Universe)", "Scientist", "Human (Cyborg)" },
                    { 34, 70, 34, "https://rickandmortyapi.com/api/character/avatar/1.jpeg", "Rick Sanchez (Phone Universe)", "Scientist", "Human (Cyborg)" },
                    { 35, 70, 35, "https://rickandmortyapi.com/api/character/avatar/1.jpeg", "Rick Sanchez (Pizza Universe)", "Scientist", "Human (Cyborg)" },
                    { 36, 70, 36, "https://rickandmortyapi.com/api/character/avatar/1.jpeg", "Rick Sanchez (Post-Apocalyptic Dimension)", "Scientist", "Human (Cyborg)" },
                    { 37, 70, 37, "https://rickandmortyapi.com/api/character/avatar/1.jpeg", "Rick Sanchez (Replacement dimension)", "Scientist", "Human (Cyborg)" },
                    { 38, 70, 38, "https://rickandmortyapi.com/api/character/avatar/1.jpeg", "Rick Sanchez (Reverse Height Universe)", "Scientist", "Human (Cyborg)" },
                    { 39, 70, 39, "https://rickandmortyapi.com/api/character/avatar/1.jpeg", "Rick Sanchez (Shrimp Universe)", "Scientist", "Human (Cyborg)" },
                    { 40, 70, 40, "https://rickandmortyapi.com/api/character/avatar/1.jpeg", "Rick Sanchez (Testicle Monster Dimension)", "Scientist", "Human (Cyborg)" },
                    { 41, 70, 41, "https://rickandmortyapi.com/api/character/avatar/1.jpeg", "Rick Sanchez (Toilet Dimension)", "Scientist", "Human (Cyborg)" },
                    { 33, 70, 33, "https://rickandmortyapi.com/api/character/avatar/1.jpeg", "Rick Sanchez (Pantless Universe)", "Scientist", "Human (Cyborg)" },
                    { 42, 70, 42, "https://rickandmortyapi.com/api/character/avatar/1.jpeg", "Rick Sanchez (Tusk Dimension)", "Scientist", "Human (Cyborg)" },
                    { 22, 70, 22, "https://rickandmortyapi.com/api/character/avatar/1.jpeg", "Rick Sanchez (Fantasy World)", "Scientist", "Human (Cyborg)" },
                    { 20, 70, 20, "https://rickandmortyapi.com/api/character/avatar/1.jpeg", "Rick Sanchez (Dog Dimension)", "Scientist", "Human (Cyborg)" },
                    { 2, 70, 2, "https://rickandmortyapi.com/api/character/avatar/1.jpeg", "Rick Sanchez (Buttworld)", "Scientist", "Human (Cyborg)" },
                    { 3, 70, 3, "https://rickandmortyapi.com/api/character/avatar/1.jpeg", "Rick Sanchez (Corn Universe)", "Scientist", "Human (Cyborg)" },
                    { 4, 70, 4, "https://rickandmortyapi.com/api/character/avatar/1.jpeg", "Rick Sanchez (Cromulon Dimension)", "Scientist", "Human (Cyborg)" },
                    { 5, 70, 5, "https://rickandmortyapi.com/api/character/avatar/1.jpeg", "Rick Sanchez (Cronenberg World)", "Scientist", "Human (Cyborg)" },
                    { 6, 70, 6, "https://rickandmortyapi.com/api/character/avatar/1.jpeg", "Rick Sanchez (Dimension 9-2184C)", "Scientist", "Human (Cyborg)" },
                    { 7, 70, 7, "https://rickandmortyapi.com/api/character/avatar/1.jpeg", "Rick Sanchez (Dimension 35-C)", "Scientist", "Human (Cyborg)" },
                    { 8, 70, 8, "https://rickandmortyapi.com/api/character/avatar/1.jpeg", "Rick Sanchez (Dimension 46)", "Scientist", "Human (Cyborg)" },
                    { 9, 70, 9, "https://rickandmortyapi.com/api/character/avatar/1.jpeg", "Rick Sanchez (Dimension 304-X)", "Scientist", "Human (Cyborg)" },
                    { 21, 70, 21, "https://rickandmortyapi.com/api/character/avatar/1.jpeg", "Rick Sanchez (Doopidoo Dimension)", "Scientist", "Human (Cyborg)" },
                    { 10, 70, 10, "https://rickandmortyapi.com/api/character/avatar/1.jpeg", "Rick Sanchez (Dimension 437)", "Scientist", "Human (Cyborg)" },
                    { 12, 70, 12, "https://rickandmortyapi.com/api/character/avatar/1.jpeg", "Rick Sanchez (Dimension C-132)", "Scientist", "Human (Cyborg)" },
                    { 13, 70, 13, "https://rickandmortyapi.com/api/character/avatar/1.jpeg", "Rick Sanchez (Dimension C-137)", "Scientist", "Human (Cyborg)" },
                    { 14, 70, 14, "https://rickandmortyapi.com/api/character/avatar/1.jpeg", "Rick Sanchez (Dimension C-500A)", "Scientist", "Human (Cyborg)" },
                    { 15, 70, 15, "https://rickandmortyapi.com/api/character/avatar/1.jpeg", "Rick Sanchez (Dimension C-1239)", "Scientist", "Human (Cyborg)" },
                    { 16, 70, 16, "https://rickandmortyapi.com/api/character/avatar/1.jpeg", "Rick Sanchez (Dimension C-4499)", "Scientist", "Human (Cyborg)" },
                    { 17, 70, 17, "https://rickandmortyapi.com/api/character/avatar/1.jpeg", "Rick Sanchez (Dimension J19α7)", "Scientist", "Human (Cyborg)" },
                    { 18, 70, 18, "https://rickandmortyapi.com/api/character/avatar/1.jpeg", "Rick Sanchez (Dimension J19ζ7)", "Scientist", "Human (Cyborg)" },
                    { 19, 70, 19, "https://rickandmortyapi.com/api/character/avatar/1.jpeg", "Rick Sanchez (Dimension Zeta-6 Epsilon)", "Scientist", "Human (Cyborg)" },
                    { 11, 70, 11, "https://rickandmortyapi.com/api/character/avatar/1.jpeg", "Rick Sanchez (Dimension Beta B-45)", "Scientist", "Human (Cyborg)" },
                    { 43, 70, 43, "https://rickandmortyapi.com/api/character/avatar/1.jpeg", "Rick Sanchez (Wasp Universe)", "Scientist", "Human (Cyborg)" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Morty_DimensionId",
                table: "Morty",
                column: "DimensionId");

            migrationBuilder.CreateIndex(
                name: "IX_Rick_DimensionId",
                table: "Rick",
                column: "DimensionId");

            migrationBuilder.CreateIndex(
                name: "IX_RickDimension_Id",
                table: "RickDimension",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RickDimension");

            migrationBuilder.DropTable(
                name: "Rick");

            migrationBuilder.DropTable(
                name: "Morty");

            migrationBuilder.DropTable(
                name: "Dimension");
        }
    }
}
