using System;
using Aplicacion_CursosJD.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Aplicacion_CursosJD.DataAccess.Context
{
    public partial class Udemy_JasondanyContext : DbContext
    {
        public Udemy_JasondanyContext()
        {
        }

        public Udemy_JasondanyContext(DbContextOptions<Udemy_JasondanyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<tbCategorias> tbCategorias { get; set; }
        public virtual DbSet<tbCursos> tbCursos { get; set; }
        public virtual DbSet<tbCusrsosPorUsuario> tbCusrsosPorUsuario { get; set; }
        public virtual DbSet<tbDepartamentos> tbDepartamentos { get; set; }
        public virtual DbSet<tbEstadosCiviles> tbEstadosCiviles { get; set; }
        public virtual DbSet<tbInfoPagos> tbInfoPagos { get; set; }
        public virtual DbSet<tbInstructores> tbInstructores { get; set; }
        public virtual DbSet<tbInstructoresPorCurso> tbInstructoresPorCurso { get; set; }
        public virtual DbSet<tbMetodosPagos> tbMetodosPagos { get; set; }
        public virtual DbSet<tbMunicipios> tbMunicipios { get; set; }
        public virtual DbSet<tbPantallas> tbPantallas { get; set; }
        public virtual DbSet<tbPantallasPorRoles> tbPantallasPorRoles { get; set; }
        public virtual DbSet<tbRecursos> tbRecursos { get; set; }
        public virtual DbSet<tbRoles> tbRoles { get; set; }
        public virtual DbSet<tbTiposRecursos> tbTiposRecursos { get; set; }
        public virtual DbSet<tbUsuarios> tbUsuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<tbCategorias>(entity =>
            {
                entity.HasKey(e => e.Cat_Id)
                    .HasName("PK__tbCatego__26E3514026355A1C");

                entity.ToTable("tbCategorias", "Curs");

                entity.Property(e => e.Cat_Estado).HasDefaultValueSql("((1))");

                entity.Property(e => e.Cat_FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.Cat_FechaModificacion).HasColumnType("datetime");

                entity.Property(e => e.Cat_Nombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Cat_UsuarioCreacionNavigation)
                    .WithMany(p => p.tbCategoriasCat_UsuarioCreacionNavigation)
                    .HasForeignKey(d => d.Cat_UsuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbCategorias_Cat_UsuarioCreacion");

                entity.HasOne(d => d.Cat_UsuarioModificacionNavigation)
                    .WithMany(p => p.tbCategoriasCat_UsuarioModificacionNavigation)
                    .HasForeignKey(d => d.Cat_UsuarioModificacion)
                    .HasConstraintName("FK_tbCategorias_Cat_UsuarioModificacion");
            });

            modelBuilder.Entity<tbCursos>(entity =>
            {
                entity.HasKey(e => e.Cur_Id)
                    .HasName("PK__tbCursos__A20112074B74B8B6");

                entity.ToTable("tbCursos", "Curs");

                entity.Property(e => e.Cur_Estado).HasDefaultValueSql("((1))");

                entity.Property(e => e.Cur_FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.Cur_FechaModificacion).HasColumnType("datetime");

                entity.Property(e => e.Cur_Nombre)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.Cat)
                    .WithMany(p => p.tbCursos)
                    .HasForeignKey(d => d.Cat_Id)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Cur_UsuarioCreacionNavigation)
                    .WithMany(p => p.tbCursosCur_UsuarioCreacionNavigation)
                    .HasForeignKey(d => d.Cur_UsuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbCursos_Cur_UsuarioCreacion");

                entity.HasOne(d => d.Cur_UsuarioModificacionNavigation)
                    .WithMany(p => p.tbCursosCur_UsuarioModificacionNavigation)
                    .HasForeignKey(d => d.Cur_UsuarioModificacion)
                    .HasConstraintName("FK_tbCursos_Cur_UsuarioModificacion");
            });

            modelBuilder.Entity<tbCusrsosPorUsuario>(entity =>
            {
                entity.HasKey(e => e.CpU_Id)
                    .HasName("PK__tbCusrso__BEA5471763DB50C6");

                entity.ToTable("tbCusrsosPorUsuario", "Curs");

                entity.Property(e => e.CpU_Estado).HasDefaultValueSql("((1))");

                entity.Property(e => e.CpU_FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.CpU_FechaModificacion).HasColumnType("datetime");

                entity.HasOne(d => d.CpU_UsuarioCreacionNavigation)
                    .WithMany(p => p.tbCusrsosPorUsuarioCpU_UsuarioCreacionNavigation)
                    .HasForeignKey(d => d.CpU_UsuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbCusrsosPorUsuario_CpU_UsuarioCreacion");

                entity.HasOne(d => d.CpU_UsuarioModificacionNavigation)
                    .WithMany(p => p.tbCusrsosPorUsuarioCpU_UsuarioModificacionNavigation)
                    .HasForeignKey(d => d.CpU_UsuarioModificacion)
                    .HasConstraintName("FK_tbCusrsosPorUsuario_CpU_UsuarioModificacion");

                entity.HasOne(d => d.Cur)
                    .WithMany(p => p.tbCusrsosPorUsuario)
                    .HasForeignKey(d => d.Cur_Id)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Usu)
                    .WithMany(p => p.tbCusrsosPorUsuarioUsu)
                    .HasForeignKey(d => d.Usu_Id)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<tbDepartamentos>(entity =>
            {
                entity.HasKey(e => e.Dep_Id)
                    .HasName("PK__tbDepart__0C2B452DE9AA1368");

                entity.ToTable("tbDepartamentos", "Gral");

                entity.Property(e => e.Dep_Id)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Dep_Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Dep_Estado).HasDefaultValueSql("((1))");

                entity.Property(e => e.Dep_FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.Dep_FechaModificacion).HasColumnType("datetime");

                entity.HasOne(d => d.Dep_UsuarioCreacionNavigation)
                    .WithMany(p => p.tbDepartamentosDep_UsuarioCreacionNavigation)
                    .HasForeignKey(d => d.Dep_UsuarioCreacion)
                    .HasConstraintName("FK_tbDepartamentos_Dep_UsuarioCreacion");

                entity.HasOne(d => d.Dep_UsuarioModificacionNavigation)
                    .WithMany(p => p.tbDepartamentosDep_UsuarioModificacionNavigation)
                    .HasForeignKey(d => d.Dep_UsuarioModificacion)
                    .HasConstraintName("FK_tbDepartamentos_Dep_UsuarioModificacion");
            });

            modelBuilder.Entity<tbEstadosCiviles>(entity =>
            {
                entity.HasKey(e => e.Est_Id)
                    .HasName("PK__tbEstado__345473BC67458AD6");

                entity.ToTable("tbEstadosCiviles", "Gral");

                entity.Property(e => e.Est_Descripcion)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Est_Estado).HasDefaultValueSql("((1))");

                entity.Property(e => e.Est_FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.Est_FechaModificacion).HasColumnType("datetime");

                entity.HasOne(d => d.Est_UsuarioCreacionNavigation)
                    .WithMany(p => p.tbEstadosCivilesEst_UsuarioCreacionNavigation)
                    .HasForeignKey(d => d.Est_UsuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbEstadosCiviles_Est_UsuarioCreacion");

                entity.HasOne(d => d.Est_UsuarioModificacionNavigation)
                    .WithMany(p => p.tbEstadosCivilesEst_UsuarioModificacionNavigation)
                    .HasForeignKey(d => d.Est_UsuarioModificacion)
                    .HasConstraintName("FK_tbEstadosCiviles_Est_UsuarioModificacion");
            });

            modelBuilder.Entity<tbInfoPagos>(entity =>
            {
                entity.HasKey(e => e.Inp_Id)
                    .HasName("PK__tbInfoPa__295F8BAFAC4F5DC0");

                entity.ToTable("tbInfoPagos", "Pago");

                entity.Property(e => e.Inp_Descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Inp_Estado).HasDefaultValueSql("((1))");

                entity.Property(e => e.Inp_FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.Inp_FechaModificacion).HasColumnType("datetime");

                entity.HasOne(d => d.Inp_UsuarioCreacionNavigation)
                    .WithMany(p => p.tbInfoPagosInp_UsuarioCreacionNavigation)
                    .HasForeignKey(d => d.Inp_UsuarioCreacion)
                    .HasConstraintName("FK_tbInfoPagos_Inp_UsuarioCreacion");

                entity.HasOne(d => d.Inp_UsuarioModificacionNavigation)
                    .WithMany(p => p.tbInfoPagosInp_UsuarioModificacionNavigation)
                    .HasForeignKey(d => d.Inp_UsuarioModificacion)
                    .HasConstraintName("FK_tbInfoPagos_Inp_UsuarioModificacion");

                entity.HasOne(d => d.Mtp)
                    .WithMany(p => p.tbInfoPagos)
                    .HasForeignKey(d => d.Mtp_Id)
                    .HasConstraintName("FK_tbMetodosPagos_tbInfoPago_Usu_Id");

                entity.HasOne(d => d.Usu)
                    .WithMany(p => p.tbInfoPagosUsu)
                    .HasForeignKey(d => d.Usu_Id)
                    .HasConstraintName("FK_tbUsuarios_tbInfoPago_Usu_Id");
            });

            modelBuilder.Entity<tbInstructores>(entity =>
            {
                entity.HasKey(e => e.Ins_Id)
                    .HasName("PK__tbInstru__151409ED7F50A809");

                entity.ToTable("tbInstructores", "Curs");

                entity.Property(e => e.Ins_Apellido)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Ins_CorreoElectronico)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Ins_Direccion)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Ins_Estado).HasDefaultValueSql("((1))");

                entity.Property(e => e.Ins_FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.Ins_FechaModificacion).HasColumnType("datetime");

                entity.Property(e => e.Ins_FechaNacimiento).HasColumnType("date");

                entity.Property(e => e.Ins_Nombre)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Ins_Sexo)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Ins_Telefono)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Mun_Id)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.Est)
                    .WithMany(p => p.tbInstructores)
                    .HasForeignKey(d => d.Est_Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbInstructores_Est_Id");

                entity.HasOne(d => d.Ins_UsuarioCreacionNavigation)
                    .WithMany(p => p.tbInstructoresIns_UsuarioCreacionNavigation)
                    .HasForeignKey(d => d.Ins_UsuarioCreacion)
                    .HasConstraintName("FK_tbInstructores_Ins_UsuarioCreacion");

                entity.HasOne(d => d.Ins_UsuarioModificacionNavigation)
                    .WithMany(p => p.tbInstructoresIns_UsuarioModificacionNavigation)
                    .HasForeignKey(d => d.Ins_UsuarioModificacion)
                    .HasConstraintName("FK_tbInstructores_Ins_UsuarioModificacion");

                entity.HasOne(d => d.Mun)
                    .WithMany(p => p.tbInstructores)
                    .HasForeignKey(d => d.Mun_Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbInstructores_Mun_Id");
            });

            modelBuilder.Entity<tbInstructoresPorCurso>(entity =>
            {
                entity.HasKey(e => e.IpC_Id)
                    .HasName("PK__tbInstru__05B34CDEC12B2218");

                entity.ToTable("tbInstructoresPorCurso", "Curs");

                entity.Property(e => e.IpC_Estado).HasDefaultValueSql("((1))");

                entity.Property(e => e.IpC_FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.IpC_FechaModificacion).HasColumnType("datetime");

                entity.HasOne(d => d.Cur)
                    .WithMany(p => p.tbInstructoresPorCurso)
                    .HasForeignKey(d => d.Cur_Id)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Ins)
                    .WithMany(p => p.tbInstructoresPorCurso)
                    .HasForeignKey(d => d.Ins_Id)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.IpC_UsuarioCreacionNavigation)
                    .WithMany(p => p.tbInstructoresPorCursoIpC_UsuarioCreacionNavigation)
                    .HasForeignKey(d => d.IpC_UsuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbInstructoresPorCurso_IpC_UsuarioCreacion");

                entity.HasOne(d => d.IpC_UsuarioModificacionNavigation)
                    .WithMany(p => p.tbInstructoresPorCursoIpC_UsuarioModificacionNavigation)
                    .HasForeignKey(d => d.IpC_UsuarioModificacion)
                    .HasConstraintName("FK_tbInstructoresPorCurso_IpC_UsuarioModificacion");
            });

            modelBuilder.Entity<tbMetodosPagos>(entity =>
            {
                entity.HasKey(e => e.Mtp_Id)
                    .HasName("PK__tbMetodo__2DDF1F87D3318112");

                entity.ToTable("tbMetodosPagos", "Pago");

                entity.Property(e => e.Mtp_Descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Mtp_Estado).HasDefaultValueSql("((1))");

                entity.Property(e => e.Mtp_FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.Mtp_FechaModificacion).HasColumnType("datetime");

                entity.HasOne(d => d.Mtp_UsuarioCreacionNavigation)
                    .WithMany(p => p.tbMetodosPagosMtp_UsuarioCreacionNavigation)
                    .HasForeignKey(d => d.Mtp_UsuarioCreacion)
                    .HasConstraintName("FK_tbMetodosPagos_Mtp_UsuarioCreacion");

                entity.HasOne(d => d.Mtp_UsuarioModificacionNavigation)
                    .WithMany(p => p.tbMetodosPagosMtp_UsuarioModificacionNavigation)
                    .HasForeignKey(d => d.Mtp_UsuarioModificacion)
                    .HasConstraintName("FK_tbMetodosPagos_Mtp_UsuarioModificacion");
            });

            modelBuilder.Entity<tbMunicipios>(entity =>
            {
                entity.HasKey(e => e.Mun_Id)
                    .HasName("PK__tbMunici__106B04B90E5FE9E5");

                entity.ToTable("tbMunicipios", "Gral");

                entity.Property(e => e.Mun_Id)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Dep_Id)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Mun_Descripcion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Mun_Estado).HasDefaultValueSql("((1))");

                entity.Property(e => e.Mun_FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.Mun_FechaModificacion).HasColumnType("datetime");

                entity.HasOne(d => d.Dep)
                    .WithMany(p => p.tbMunicipios)
                    .HasForeignKey(d => d.Dep_Id)
                    .HasConstraintName("FK_tbMunicipios_Dep_Id");

                entity.HasOne(d => d.Mun_UsuarioCreacionNavigation)
                    .WithMany(p => p.tbMunicipiosMun_UsuarioCreacionNavigation)
                    .HasForeignKey(d => d.Mun_UsuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbMunicipios_Mun_UsuarioCreacion");

                entity.HasOne(d => d.Mun_UsuarioModificacionNavigation)
                    .WithMany(p => p.tbMunicipiosMun_UsuarioModificacionNavigation)
                    .HasForeignKey(d => d.Mun_UsuarioModificacion)
                    .HasConstraintName("FK_tbMunicipios_Mun_UsuarioModificacion");
            });

            modelBuilder.Entity<tbPantallas>(entity =>
            {
                entity.HasKey(e => e.Pan_Id)
                    .HasName("PK__tbPantal__C2D2D1017E6A8ED7");

                entity.ToTable("tbPantallas", "Acce");

                entity.Property(e => e.Pan_Descripcion)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Pan_Estado).HasDefaultValueSql("((1))");

                entity.Property(e => e.Pan_FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.Pan_FechaModificacion).HasColumnType("datetime");

                entity.HasOne(d => d.Pan_UsuarioCreacionNavigation)
                    .WithMany(p => p.tbPantallasPan_UsuarioCreacionNavigation)
                    .HasForeignKey(d => d.Pan_UsuarioCreacion)
                    .HasConstraintName("FK_tbPantallas_Pan_UsuarioCreacion");

                entity.HasOne(d => d.Pan_UsuarioModificacionNavigation)
                    .WithMany(p => p.tbPantallasPan_UsuarioModificacionNavigation)
                    .HasForeignKey(d => d.Pan_UsuarioModificacion)
                    .HasConstraintName("FK_tbPantallas_Pan_UsuarioModificacion");
            });

            modelBuilder.Entity<tbPantallasPorRoles>(entity =>
            {
                entity.HasKey(e => e.Ppr_Id)
                    .HasName("PK__tbPantal__BB9E04FC359B3F1D");

                entity.ToTable("tbPantallasPorRoles", "Acce");

                entity.Property(e => e.Ppr_Estado).HasDefaultValueSql("((1))");

                entity.Property(e => e.Ppr_FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.Ppr_FechaModificacion).HasColumnType("datetime");

                entity.HasOne(d => d.Pan)
                    .WithMany(p => p.tbPantallasPorRoles)
                    .HasForeignKey(d => d.Pan_Id);

                entity.HasOne(d => d.Ppr_UsuarioCreacionNavigation)
                    .WithMany(p => p.tbPantallasPorRolesPpr_UsuarioCreacionNavigation)
                    .HasForeignKey(d => d.Ppr_UsuarioCreacion)
                    .HasConstraintName("FK_tbPantallas_Ppr_UsuarioCreacion");

                entity.HasOne(d => d.Ppr_UsuarioModificacionNavigation)
                    .WithMany(p => p.tbPantallasPorRolesPpr_UsuarioModificacionNavigation)
                    .HasForeignKey(d => d.Ppr_UsuarioModificacion)
                    .HasConstraintName("FK_tbPantallas_Ppr_UsuarioModificacion");

                entity.HasOne(d => d.Rol)
                    .WithMany(p => p.tbPantallasPorRoles)
                    .HasForeignKey(d => d.Rol_Id);
            });

            modelBuilder.Entity<tbRecursos>(entity =>
            {
                entity.HasKey(e => e.Rec_Id)
                    .HasName("PK__tbRecurs__81BCD9CAE01F723F");

                entity.ToTable("tbRecursos", "Curs");

                entity.Property(e => e.Rec_Estado).HasDefaultValueSql("((1))");

                entity.Property(e => e.Rec_FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.Rec_FechaModificacion).HasColumnType("datetime");

                entity.Property(e => e.Rec_Nombre)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Rec_Url)
                    .IsRequired()
                    .IsUnicode(false);

                entity.HasOne(d => d.Cur)
                    .WithMany(p => p.tbRecursos)
                    .HasForeignKey(d => d.Cur_Id)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Rec_UsuarioCreacionNavigation)
                    .WithMany(p => p.tbRecursosRec_UsuarioCreacionNavigation)
                    .HasForeignKey(d => d.Rec_UsuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbRecursos_Rec_UsuarioCreacion");

                entity.HasOne(d => d.Rec_UsuarioModificacionNavigation)
                    .WithMany(p => p.tbRecursosRec_UsuarioModificacionNavigation)
                    .HasForeignKey(d => d.Rec_UsuarioModificacion)
                    .HasConstraintName("FK_tbRecursos_Rec_UsuarioModificacion");

                entity.HasOne(d => d.TpR)
                    .WithMany(p => p.tbRecursos)
                    .HasForeignKey(d => d.TpR_Id);
            });

            modelBuilder.Entity<tbRoles>(entity =>
            {
                entity.HasKey(e => e.Rol_Id)
                    .HasName("PK__tbRoles__795EBD4990084A76");

                entity.ToTable("tbRoles", "Acce");

                entity.Property(e => e.Rol_Descripcion)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Rol_Estado).HasDefaultValueSql("((1))");

                entity.Property(e => e.Rol_FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.Rol_FechaModificacion).HasColumnType("datetime");

                entity.HasOne(d => d.Rol_UsuarioCreacionNavigation)
                    .WithMany(p => p.tbRolesRol_UsuarioCreacionNavigation)
                    .HasForeignKey(d => d.Rol_UsuarioCreacion)
                    .HasConstraintName("FK_tbPantallas_Rol_UsuarioCreacion");

                entity.HasOne(d => d.Rol_UsuarioModificacionNavigation)
                    .WithMany(p => p.tbRolesRol_UsuarioModificacionNavigation)
                    .HasForeignKey(d => d.Rol_UsuarioModificacion)
                    .HasConstraintName("FK_tbPantallas_Rol_UsuarioModificacion");
            });

            modelBuilder.Entity<tbTiposRecursos>(entity =>
            {
                entity.HasKey(e => e.TpR_Id)
                    .HasName("PK__tbTiposR__44206F0D7748406C");

                entity.ToTable("tbTiposRecursos", "Curs");

                entity.Property(e => e.TpR_Descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TpR_Estado).HasDefaultValueSql("((1))");

                entity.Property(e => e.TpR_FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.TpR_FechaModificacion).HasColumnType("datetime");

                entity.HasOne(d => d.TpR_UsuarioCreacionNavigation)
                    .WithMany(p => p.tbTiposRecursosTpR_UsuarioCreacionNavigation)
                    .HasForeignKey(d => d.TpR_UsuarioCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbTiposRecursos_TpR_UsuarioCreacion");

                entity.HasOne(d => d.TpR_UsuarioModificacionNavigation)
                    .WithMany(p => p.tbTiposRecursosTpR_UsuarioModificacionNavigation)
                    .HasForeignKey(d => d.TpR_UsuarioModificacion)
                    .HasConstraintName("FK_tbTiposRecursos_TpR_UsuarioModificacion");
            });

            modelBuilder.Entity<tbUsuarios>(entity =>
            {
                entity.HasKey(e => e.Usu_Id)
                    .HasName("PK__tbUsuari__B6173FCBCE9ACD17");

                entity.ToTable("tbUsuarios", "Acce");

                entity.Property(e => e.Mun_Id)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Usu_Apellido)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Usu_Contrasena).IsUnicode(false);

                entity.Property(e => e.Usu_CorreoElectronico).IsUnicode(false);

                entity.Property(e => e.Usu_Direccion).IsUnicode(false);

                entity.Property(e => e.Usu_Estado).HasDefaultValueSql("((1))");

                entity.Property(e => e.Usu_FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.Usu_FechaModificacion).HasColumnType("datetime");

                entity.Property(e => e.Usu_FechaNacimiento).HasColumnType("date");

                entity.Property(e => e.Usu_Nombre)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Usu_Sexo)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Usu_Telefono)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Usu_Usuario)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Est)
                    .WithMany(p => p.tbUsuarios)
                    .HasForeignKey(d => d.Est_Id);

                entity.HasOne(d => d.Mun)
                    .WithMany(p => p.tbUsuarios)
                    .HasForeignKey(d => d.Mun_Id);

                entity.HasOne(d => d.Rol)
                    .WithMany(p => p.tbUsuarios)
                    .HasForeignKey(d => d.Rol_Id);

                entity.HasOne(d => d.Usu_UsuarioCreacionNavigation)
                    .WithMany(p => p.InverseUsu_UsuarioCreacionNavigation)
                    .HasForeignKey(d => d.Usu_UsuarioCreacion)
                    .HasConstraintName("FK_tbUsuarios_Usu_Id");

                entity.HasOne(d => d.Usu_UsuarioModificacionNavigation)
                    .WithMany(p => p.InverseUsu_UsuarioModificacionNavigation)
                    .HasForeignKey(d => d.Usu_UsuarioModificacion)
                    .HasConstraintName("FK_tbUsuarios_Usu_UsuarioModificacion");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}