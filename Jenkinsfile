pipeline {
    agent any
    
    environment {
        GIT_REPO = 'https://github.com/your-repo.git'
        EMAIL_RECIPIENT = 'agastyakapoor40@gmail.com'
    }
    
    triggers {
        pollSCM('H/2* * * * *') // Poll GitHub for changes every minute
    }
    
    stages {
        stage('Checkout Code') {
            steps {
                script {
                    echo 'Pulling the latest code from GitHub...'
                    sh 'git clone ${GIT_REPO} project && cd project'
                }
            }
        }
        
        stage('Build') {
            steps {
                script {
                    echo 'Simulating build process...'
                }
            }
            post {
                success {
                    mail to: EMAIL_RECIPIENT,
                         subject: "Build Stage Completed",
                         body: "Build stage has completed successfully."
                }
            }
        }
        
        stage('Unit and Integration Tests') {
            steps {
                script {
                    echo 'Simulating unit and integration tests...'
                }
            }
            post {
                success {
                    mail to: EMAIL_RECIPIENT,
                         subject: "Test Stage Completed",
                         body: "Unit and integration tests stage has completed successfully."
                }
            }
        }
        
        stage('Code Analysis') {
            steps {
                script {
                    echo 'Simulating code analysis...'
                }
            }
            post {
                success {
                    mail to: EMAIL_RECIPIENT,
                         subject: "Code Analysis Completed",
                         body: "Code analysis stage has completed successfully."
                }
            }
        }
        
        stage('Security Scan') {
            steps {
                script {
                    echo 'Simulating security scan...'
                }
            }
            post {
                success {
                    mail to: EMAIL_RECIPIENT,
                         subject: "Security Scan Completed",
                         body: "Security scan stage has completed successfully."
                }
            }
        }
        
        stage('Deploy to Staging') {
            steps {
                script {
                    echo 'Simulating deployment to staging...'
                }
            }
            post {
                success {
                    mail to: EMAIL_RECIPIENT,
                         subject: "Staging Deployment Completed",
                         body: "Deployment to staging has completed successfully."
                }
            }
        }
        
        stage('Integration Tests on Staging') {
            steps {
                script {
                    echo 'Simulating integration tests on staging...'
                }
            }
            post {
                success {
                    mail to: EMAIL_RECIPIENT,
                         subject: "Integration Tests on Staging Completed",
                         body: "Integration tests on staging have completed successfully."
                }
            }
        }
        
        stage('Deploy to Production') {
            steps {
                script {
                    echo 'Simulating deployment to production...'
                }
            }
            post {
                success {
                    mail to: EMAIL_RECIPIENT,
                         subject: "Production Deployment Completed",
                         body: "Deployment to production has completed successfully."
                }
            }
        }
    }
    
    post {
        failure {
            mail to: EMAIL_RECIPIENT,
                 subject: "Jenkins Build Failed",
                 body: "The Jenkins pipeline has failed. Check logs for details."
        }
    }
}
