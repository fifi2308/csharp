<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

return new class extends Migration
{
    /**
     * Run the migrations.
     */
    public function up(): void
    {
       Schema::create('rendez_vous', function (Blueprint $table) {
    $table->id('id_rv');
    $table->string('heure_debut');
    $table->string('heure_fin');
    $table->string('statut');
    $table->date('date_demande')->nullable();

    $table->unsignedBigInteger('id_soin');
    $table->unsignedBigInteger('id_patient');
    $table->unsignedBigInteger('id_medecin');
    $table->unsignedBigInteger('id_moyen_paiement');
    $table->unsignedBigInteger('id_agenda')->nullable();

    $table->foreign('id_soin')->references('id')->on('soins');
    $table->foreign('id_patient')->references('id')->on('patients');
    $table->foreign('id_medecin')->references('id')->on('medecins');
    $table->foreign('id_moyen_paiement')->references('id')->on('moyen_paiements');
    $table->foreign('id_agenda')->references('id_agenda')->on('agendas');
    $table->timestamps();
});

    }

    /**
     * Reverse the migrations.
     */
    public function down(): void
    {
        Schema::dropIfExists('rendez_vous');
    }
};
