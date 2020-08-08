using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace database.portal.jenn.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cidade",
                columns: table => new
                {
                    cod_cidade = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nom_cid = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cidade", x => x.cod_cidade);
                });

            migrationBuilder.CreateTable(
                name: "contato",
                columns: table => new
                {
                    cod_cont = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nom_cont = table.Column<string>(maxLength: 200, nullable: false),
                    tele_cont = table.Column<string>(maxLength: 200, nullable: true),
                    email_cont = table.Column<string>(maxLength: 200, nullable: false),
                    mensagem_cont = table.Column<string>(maxLength: 800, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contato", x => x.cod_cont);
                });

            migrationBuilder.CreateTable(
                name: "conv",
                columns: table => new
                {
                    cod_conv = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nom_conv = table.Column<string>(maxLength: 200, nullable: false),
                    data_inc = table.Column<DateTime>(nullable: false),
                    atv_proced = table.Column<int>(maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_conv", x => x.cod_conv);
                });

            migrationBuilder.CreateTable(
                name: "grupo",
                columns: table => new
                {
                    cod_grupo = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nom_grupo = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_grupo", x => x.cod_grupo);
                });

            migrationBuilder.CreateTable(
                name: "Logon",
                columns: table => new
                {
                    LogonID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    usua_nome = table.Column<string>(maxLength: 200, nullable: false),
                    usua_email = table.Column<string>(maxLength: 150, nullable: false),
                    password = table.Column<string>(maxLength: 100, nullable: false),
                    dt_inclusao = table.Column<DateTime>(nullable: false),
                    atv_logon = table.Column<int>(maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logon", x => x.LogonID);
                });

            migrationBuilder.CreateTable(
                name: "pais",
                columns: table => new
                {
                    cod_pais = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nom_pais = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pais", x => x.cod_pais);
                });

            migrationBuilder.CreateTable(
                name: "pgto",
                columns: table => new
                {
                    cod_pgto = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nom_pgto = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pgto", x => x.cod_pgto);
                });

            migrationBuilder.CreateTable(
                name: "procedcat",
                columns: table => new
                {
                    cod_categoria = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nom_categoria = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_procedcat", x => x.cod_categoria);
                });

            migrationBuilder.CreateTable(
                name: "cliente",
                columns: table => new
                {
                    cod_cliente = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nom_cliente = table.Column<string>(maxLength: 100, nullable: false),
                    sobnom_cliente = table.Column<string>(maxLength: 100, nullable: false),
                    nasc_cliente = table.Column<DateTime>(nullable: false),
                    cpf_cliente = table.Column<string>(maxLength: 11, nullable: false),
                    sex_cliente = table.Column<string>(maxLength: 1, nullable: false),
                    tel_cliente = table.Column<string>(maxLength: 20, nullable: false),
                    cel_cliente = table.Column<string>(maxLength: 21, nullable: true),
                    logr_cliente = table.Column<string>(maxLength: 150, nullable: true),
                    num_cliente = table.Column<string>(maxLength: 12, nullable: true),
                    bai_cliente = table.Column<string>(maxLength: 100, nullable: true),
                    cep_cliente = table.Column<string>(maxLength: 20, nullable: true),
                    refer_cliente = table.Column<string>(maxLength: 200, nullable: true),
                    CidadeID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cliente", x => x.cod_cliente);
                    table.ForeignKey(
                        name: "FK_cliente_cidade_CidadeID",
                        column: x => x.CidadeID,
                        principalTable: "cidade",
                        principalColumn: "cod_cidade",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "regiao",
                columns: table => new
                {
                    cod_regiao = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nom_reg = table.Column<string>(maxLength: 200, nullable: false),
                    CidadeID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_regiao", x => x.cod_regiao);
                    table.ForeignKey(
                        name: "FK_regiao_cidade_CidadeID",
                        column: x => x.CidadeID,
                        principalTable: "cidade",
                        principalColumn: "cod_cidade",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "plano_conv",
                columns: table => new
                {
                    cod_plano = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nom_plano = table.Column<string>(maxLength: 200, nullable: false),
                    ConvenioId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_plano_conv", x => x.cod_plano);
                    table.ForeignKey(
                        name: "FK_plano_conv_conv_ConvenioId",
                        column: x => x.ConvenioId,
                        principalTable: "conv",
                        principalColumn: "cod_conv",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "emp",
                columns: table => new
                {
                    cod_emp = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    cod_matriz_emp = table.Column<int>(nullable: true),
                    cnpj_emp = table.Column<string>(maxLength: 14, nullable: false),
                    nome_emp = table.Column<string>(maxLength: 200, nullable: false),
                    tel_emp1 = table.Column<string>(maxLength: 20, nullable: false),
                    tel_emp2 = table.Column<string>(maxLength: 20, nullable: true),
                    imgfront_emp = table.Column<string>(maxLength: 100, nullable: true),
                    mail_emp = table.Column<string>(maxLength: 100, nullable: true),
                    logr_emp = table.Column<string>(maxLength: 150, nullable: false),
                    num_emp = table.Column<string>(maxLength: 12, nullable: false),
                    bai_emp = table.Column<string>(maxLength: 100, nullable: false),
                    cep_emp = table.Column<string>(maxLength: 16, nullable: false),
                    maps_emp = table.Column<string>(maxLength: 200, nullable: true),
                    reps_emp = table.Column<string>(maxLength: 200, nullable: false),
                    id_classe = table.Column<string>(maxLength: 10, nullable: true),
                    cert_emp = table.Column<string>(maxLength: 2, nullable: true),
                    atv_proced = table.Column<int>(maxLength: 1, nullable: false),
                    GrupoID = table.Column<int>(nullable: true),
                    CidadeID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_emp", x => x.cod_emp);
                    table.ForeignKey(
                        name: "FK_emp_cidade_CidadeID",
                        column: x => x.CidadeID,
                        principalTable: "cidade",
                        principalColumn: "cod_cidade",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_emp_grupo_GrupoID",
                        column: x => x.GrupoID,
                        principalTable: "grupo",
                        principalColumn: "cod_grupo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_emp_emp_cod_matriz_emp",
                        column: x => x.cod_matriz_emp,
                        principalTable: "emp",
                        principalColumn: "cod_emp",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "papeis",
                columns: table => new
                {
                    RoleID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    papel = table.Column<string>(maxLength: 100, nullable: false),
                    LogonID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_papeis", x => x.RoleID);
                    table.ForeignKey(
                        name: "FK_papeis_Logon_LogonID",
                        column: x => x.LogonID,
                        principalTable: "Logon",
                        principalColumn: "LogonID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "uf",
                columns: table => new
                {
                    cod_uf = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nom_uf = table.Column<string>(maxLength: 200, nullable: false),
                    PaisID = table.Column<int>(nullable: true),
                    CidadeID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_uf", x => x.cod_uf);
                    table.ForeignKey(
                        name: "FK_uf_cidade_CidadeID",
                        column: x => x.CidadeID,
                        principalTable: "cidade",
                        principalColumn: "cod_cidade",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_uf_pais_PaisID",
                        column: x => x.PaisID,
                        principalTable: "pais",
                        principalColumn: "cod_pais",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tipo_proced",
                columns: table => new
                {
                    cod_tipproced = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nom_tipproced = table.Column<string>(maxLength: 200, nullable: false),
                    CategoriaID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipo_proced", x => x.cod_tipproced);
                    table.ForeignKey(
                        name: "FK_tipo_proced_procedcat_CategoriaID",
                        column: x => x.CategoriaID,
                        principalTable: "procedcat",
                        principalColumn: "cod_categoria",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "usuario",
                columns: table => new
                {
                    cod_usuario = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    mail_usuario = table.Column<string>(maxLength: 100, nullable: false),
                    Nome = table.Column<string>(maxLength: 100, nullable: false),
                    LogonID = table.Column<int>(nullable: true),
                    ClienteID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario", x => x.cod_usuario);
                    table.ForeignKey(
                        name: "FK_usuario_cliente_ClienteID",
                        column: x => x.ClienteID,
                        principalTable: "cliente",
                        principalColumn: "cod_cliente",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_usuario_Logon_LogonID",
                        column: x => x.LogonID,
                        principalTable: "Logon",
                        principalColumn: "LogonID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "avalia",
                columns: table => new
                {
                    cod_avalia = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nps_avalia = table.Column<string>(maxLength: 4, nullable: false),
                    obs_avalia = table.Column<string>(maxLength: 400, nullable: false),
                    feedback_avalia = table.Column<string>(maxLength: 2, nullable: false),
                    EmpresaID = table.Column<int>(nullable: true),
                    ClienteID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_avalia", x => x.cod_avalia);
                    table.ForeignKey(
                        name: "FK_avalia_cliente_ClienteID",
                        column: x => x.ClienteID,
                        principalTable: "cliente",
                        principalColumn: "cod_cliente",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_avalia_emp_EmpresaID",
                        column: x => x.EmpresaID,
                        principalTable: "emp",
                        principalColumn: "cod_emp",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "fotoemp",
                columns: table => new
                {
                    cod_foto = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    path_emp = table.Column<string>(maxLength: 100, nullable: false),
                    nome_foto = table.Column<string>(maxLength: 100, nullable: false),
                    EmpresaID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fotoemp", x => x.cod_foto);
                    table.ForeignKey(
                        name: "FK_fotoemp_emp_EmpresaID",
                        column: x => x.EmpresaID,
                        principalTable: "emp",
                        principalColumn: "cod_emp",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "proced",
                columns: table => new
                {
                    cod_proced = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nom_proced = table.Column<string>(maxLength: 200, nullable: false),
                    desc_proced = table.Column<string>(maxLength: 400, nullable: false),
                    imgprod_proced = table.Column<string>(maxLength: 200, nullable: false),
                    atv_proced = table.Column<int>(maxLength: 1, nullable: false),
                    TipoProcedimentoID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_proced", x => x.cod_proced);
                    table.ForeignKey(
                        name: "FK_proced_tipo_proced_TipoProcedimentoID",
                        column: x => x.TipoProcedimentoID,
                        principalTable: "tipo_proced",
                        principalColumn: "cod_tipproced",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "procemp",
                columns: table => new
                {
                    cod_procemp = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    dataincl_procemp = table.Column<DateTime>(nullable: false),
                    nompers_procemp = table.Column<string>(maxLength: 100, nullable: false),
                    precoprod_procemp = table.Column<float>(nullable: false),
                    precocontra_procemp = table.Column<float>(nullable: false),
                    txtparcel_procemp = table.Column<string>(maxLength: 200, nullable: false),
                    txtresult_procemp = table.Column<string>(maxLength: 200, nullable: false),
                    imgthumb_procemp = table.Column<string>(maxLength: 100, nullable: false),
                    imghome_procemp = table.Column<string>(maxLength: 100, nullable: false),
                    imgmain_procemp = table.Column<string>(maxLength: 100, nullable: false),
                    video_procemp = table.Column<string>(maxLength: 100, nullable: false),
                    atv_proced = table.Column<int>(nullable: false),
                    dest_proced = table.Column<int>(nullable: true),
                    cod_proced = table.Column<int>(nullable: false),
                    cod_emp = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_procemp", x => x.cod_procemp);
                    table.ForeignKey(
                        name: "FK_procemp_emp_cod_emp",
                        column: x => x.cod_emp,
                        principalTable: "emp",
                        principalColumn: "cod_emp",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_procemp_proced_cod_proced",
                        column: x => x.cod_proced,
                        principalTable: "proced",
                        principalColumn: "cod_proced",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "domic",
                columns: table => new
                {
                    cod_domic = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    precodom_domic = table.Column<float>(maxLength: 4, nullable: false),
                    CidadeID = table.Column<int>(nullable: true),
                    ProcedimentoEmpresaID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_domic", x => x.cod_domic);
                    table.ForeignKey(
                        name: "FK_domic_cidade_CidadeID",
                        column: x => x.CidadeID,
                        principalTable: "cidade",
                        principalColumn: "cod_cidade",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_domic_procemp_ProcedimentoEmpresaID",
                        column: x => x.ProcedimentoEmpresaID,
                        principalTable: "procemp",
                        principalColumn: "cod_procemp",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "pgtoprocemp",
                columns: table => new
                {
                    cod_pgtoprocemp = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PagamentoID = table.Column<int>(nullable: true),
                    ProcedimentoEmpresaID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pgtoprocemp", x => x.cod_pgtoprocemp);
                    table.ForeignKey(
                        name: "FK_pgtoprocemp_pgto_PagamentoID",
                        column: x => x.PagamentoID,
                        principalTable: "pgto",
                        principalColumn: "cod_pgto",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_pgtoprocemp_procemp_ProcedimentoEmpresaID",
                        column: x => x.ProcedimentoEmpresaID,
                        principalTable: "procemp",
                        principalColumn: "cod_procemp",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "planoprocemp",
                columns: table => new
                {
                    cod_planoprocemp = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProcedimentoEmpresaID = table.Column<int>(nullable: true),
                    PlanoID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_planoprocemp", x => x.cod_planoprocemp);
                    table.ForeignKey(
                        name: "FK_planoprocemp_plano_conv_PlanoID",
                        column: x => x.PlanoID,
                        principalTable: "plano_conv",
                        principalColumn: "cod_plano",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_planoprocemp_procemp_ProcedimentoEmpresaID",
                        column: x => x.ProcedimentoEmpresaID,
                        principalTable: "procemp",
                        principalColumn: "cod_procemp",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "proceagenda",
                columns: table => new
                {
                    cod_agenda = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    agen_mes = table.Column<int>(nullable: false),
                    agen_dia = table.Column<int>(nullable: false),
                    agen_hora = table.Column<DateTime>(nullable: false),
                    agen_datvige = table.Column<DateTime>(nullable: false),
                    agen_atv = table.Column<bool>(nullable: false),
                    ProcedimentoEmpresaID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_proceagenda", x => x.cod_agenda);
                    table.ForeignKey(
                        name: "FK_proceagenda_procemp_ProcedimentoEmpresaID",
                        column: x => x.ProcedimentoEmpresaID,
                        principalTable: "procemp",
                        principalColumn: "cod_procemp",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "procperg",
                columns: table => new
                {
                    cod_procperg = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    titulo_procperg = table.Column<string>(maxLength: 150, nullable: false),
                    desc_procperg = table.Column<string>(maxLength: 300, nullable: false),
                    atv_proced = table.Column<int>(maxLength: 1, nullable: false),
                    ProcedimentoEmpresaID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_procperg", x => x.cod_procperg);
                    table.ForeignKey(
                        name: "FK_procperg_procemp_ProcedimentoEmpresaID",
                        column: x => x.ProcedimentoEmpresaID,
                        principalTable: "procemp",
                        principalColumn: "cod_procemp",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "proceagendaconfirma",
                columns: table => new
                {
                    cod_confirma_agenda = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    num_carteirinha_convenio = table.Column<string>(maxLength: 200, nullable: false),
                    bln_contr = table.Column<ulong>(type: "bit", nullable: false),
                    bln_paciente_tiular = table.Column<ulong>(type: "bit", nullable: false),
                    peso_paciente = table.Column<float>(type: "float", nullable: false),
                    altura_pac = table.Column<float>(type: "float", nullable: false),
                    alergia_reacoes = table.Column<string>(nullable: false),
                    PlanoID = table.Column<int>(nullable: true),
                    AgendaID = table.Column<int>(nullable: true),
                    ClienteID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_proceagendaconfirma", x => x.cod_confirma_agenda);
                    table.ForeignKey(
                        name: "FK_proceagendaconfirma_proceagenda_AgendaID",
                        column: x => x.AgendaID,
                        principalTable: "proceagenda",
                        principalColumn: "cod_agenda",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_proceagendaconfirma_cliente_ClienteID",
                        column: x => x.ClienteID,
                        principalTable: "cliente",
                        principalColumn: "cod_cliente",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_proceagendaconfirma_plano_conv_PlanoID",
                        column: x => x.PlanoID,
                        principalTable: "plano_conv",
                        principalColumn: "cod_plano",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_avalia_ClienteID",
                table: "avalia",
                column: "ClienteID");

            migrationBuilder.CreateIndex(
                name: "IX_avalia_EmpresaID",
                table: "avalia",
                column: "EmpresaID");

            migrationBuilder.CreateIndex(
                name: "IX_cliente_CidadeID",
                table: "cliente",
                column: "CidadeID");

            migrationBuilder.CreateIndex(
                name: "IX_domic_CidadeID",
                table: "domic",
                column: "CidadeID");

            migrationBuilder.CreateIndex(
                name: "IX_domic_ProcedimentoEmpresaID",
                table: "domic",
                column: "ProcedimentoEmpresaID");

            migrationBuilder.CreateIndex(
                name: "IX_emp_CidadeID",
                table: "emp",
                column: "CidadeID");

            migrationBuilder.CreateIndex(
                name: "IX_emp_GrupoID",
                table: "emp",
                column: "GrupoID");

            migrationBuilder.CreateIndex(
                name: "IX_emp_cod_matriz_emp",
                table: "emp",
                column: "cod_matriz_emp");

            migrationBuilder.CreateIndex(
                name: "IX_fotoemp_EmpresaID",
                table: "fotoemp",
                column: "EmpresaID");

            migrationBuilder.CreateIndex(
                name: "IX_papeis_LogonID",
                table: "papeis",
                column: "LogonID");

            migrationBuilder.CreateIndex(
                name: "IX_pgtoprocemp_PagamentoID",
                table: "pgtoprocemp",
                column: "PagamentoID");

            migrationBuilder.CreateIndex(
                name: "IX_pgtoprocemp_ProcedimentoEmpresaID",
                table: "pgtoprocemp",
                column: "ProcedimentoEmpresaID");

            migrationBuilder.CreateIndex(
                name: "IX_plano_conv_ConvenioId",
                table: "plano_conv",
                column: "ConvenioId");

            migrationBuilder.CreateIndex(
                name: "IX_planoprocemp_PlanoID",
                table: "planoprocemp",
                column: "PlanoID");

            migrationBuilder.CreateIndex(
                name: "IX_planoprocemp_ProcedimentoEmpresaID",
                table: "planoprocemp",
                column: "ProcedimentoEmpresaID");

            migrationBuilder.CreateIndex(
                name: "IX_proceagenda_ProcedimentoEmpresaID",
                table: "proceagenda",
                column: "ProcedimentoEmpresaID");

            migrationBuilder.CreateIndex(
                name: "IX_proceagendaconfirma_AgendaID",
                table: "proceagendaconfirma",
                column: "AgendaID");

            migrationBuilder.CreateIndex(
                name: "IX_proceagendaconfirma_ClienteID",
                table: "proceagendaconfirma",
                column: "ClienteID");

            migrationBuilder.CreateIndex(
                name: "IX_proceagendaconfirma_PlanoID",
                table: "proceagendaconfirma",
                column: "PlanoID");

            migrationBuilder.CreateIndex(
                name: "IX_proced_TipoProcedimentoID",
                table: "proced",
                column: "TipoProcedimentoID");

            migrationBuilder.CreateIndex(
                name: "IX_procemp_cod_proced",
                table: "procemp",
                column: "cod_proced");

            migrationBuilder.CreateIndex(
                name: "IX_procemp_cod_emp_cod_proced",
                table: "procemp",
                columns: new[] { "cod_emp", "cod_proced" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_procperg_ProcedimentoEmpresaID",
                table: "procperg",
                column: "ProcedimentoEmpresaID");

            migrationBuilder.CreateIndex(
                name: "IX_regiao_CidadeID",
                table: "regiao",
                column: "CidadeID");

            migrationBuilder.CreateIndex(
                name: "IX_tipo_proced_CategoriaID",
                table: "tipo_proced",
                column: "CategoriaID");

            migrationBuilder.CreateIndex(
                name: "IX_uf_CidadeID",
                table: "uf",
                column: "CidadeID");

            migrationBuilder.CreateIndex(
                name: "IX_uf_PaisID",
                table: "uf",
                column: "PaisID");

            migrationBuilder.CreateIndex(
                name: "IX_usuario_ClienteID",
                table: "usuario",
                column: "ClienteID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_usuario_LogonID",
                table: "usuario",
                column: "LogonID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "avalia");

            migrationBuilder.DropTable(
                name: "contato");

            migrationBuilder.DropTable(
                name: "domic");

            migrationBuilder.DropTable(
                name: "fotoemp");

            migrationBuilder.DropTable(
                name: "papeis");

            migrationBuilder.DropTable(
                name: "pgtoprocemp");

            migrationBuilder.DropTable(
                name: "planoprocemp");

            migrationBuilder.DropTable(
                name: "proceagendaconfirma");

            migrationBuilder.DropTable(
                name: "procperg");

            migrationBuilder.DropTable(
                name: "regiao");

            migrationBuilder.DropTable(
                name: "uf");

            migrationBuilder.DropTable(
                name: "usuario");

            migrationBuilder.DropTable(
                name: "pgto");

            migrationBuilder.DropTable(
                name: "proceagenda");

            migrationBuilder.DropTable(
                name: "plano_conv");

            migrationBuilder.DropTable(
                name: "pais");

            migrationBuilder.DropTable(
                name: "cliente");

            migrationBuilder.DropTable(
                name: "Logon");

            migrationBuilder.DropTable(
                name: "procemp");

            migrationBuilder.DropTable(
                name: "conv");

            migrationBuilder.DropTable(
                name: "emp");

            migrationBuilder.DropTable(
                name: "proced");

            migrationBuilder.DropTable(
                name: "cidade");

            migrationBuilder.DropTable(
                name: "grupo");

            migrationBuilder.DropTable(
                name: "tipo_proced");

            migrationBuilder.DropTable(
                name: "procedcat");
        }
    }
}
